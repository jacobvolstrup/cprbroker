﻿CREATE PROCEDURE [dbo].[UpdatePersonLists]
	@Now datetime,
	@SubscriptionTypeId Int
AS
	DECLARE @EmptyUuid uniqueidentifier;
	SET @EmptyUuid = '{00000000-0000-0000-0000-000000000000}'

	---------------------------------------------------------------------------------------------------
	--- Create a temp table with the changed persons and their in/out status before and after the change
	---------------------------------------------------------------------------------------------------
	DECLARE @TMP TABLE(SubscriptionId uniqueidentifier, PersonUuid uniqueidentifier, PersonRegistrationId uniqueidentifier, SubscriptionPersonId uniqueidentifier, SubscriptionCriteriaMatchId uniqueidentifier)
	
	INSERT INTO 
		@TMP 
	SELECT
		S_DCE.SubscriptionId,
		S_DCE.PersonUuid, 
		S_DCE.PersonRegistrationId,
		SP.SubscriptionPersonId,
		SCM.SubscriptionCriteriaMatchId
	FROM
		(
			SELECT * FROM Subscription S, DataChangeEvent DCE
			WHERE S.SubscriptionTypeId = @SubscriptionTypeId AND S.Criteria IS NOT NULL AND S.Deactivated IS NULL
		) AS S_DCE
	LEFT OUTER JOIN SubscriptionPerson SP			ON S_DCE.SubscriptionId = SP.SubscriptionId		AND	S_DCE.PersonUuid		= SP.PersonUuid
	LEFT OUTER JOIN SubscriptionCriteriaMatch SCM	ON S_DCE.SubscriptionId = SCM.SubscriptionId	AND	S_DCE.DataChangeEventId	= SCM.DataChangeEventId
	WHERE
		SP.Removed IS NULL

	---------------------------------------------------------------------------------------------------
	--- Insert persons that have now changed to be in the criteria
	---------------------------------------------------------------------------------------------------
	INSERT INTO SubscriptionPerson(SubscriptionId, PersonUuid, Created)
	SELECT SubscriptionId, PersonUuid, @Now
	FROM @TMP T
	WHERE 
			T.SubscriptionPersonId IS NULL 
		AND SubscriptionCriteriaMatchId IS NOT NULL


	---------------------------------------------------------------------------------------------------
	--- Remove persons that no longer match the subscription's criteria
	---------------------------------------------------------------------------------------------------
	UPDATE 
		SP
	SET 
		Removed = 1
	FROM 
		SubscriptionPerson SP INNER JOIN @TMP T 
		ON 
			T.SubscriptionPersonId = SP.SubscriptionPersonId
	WHERE 
		-- No need for T.SubscriptionPersonId IS NOT NULL because it is implicitly included in the join condition
		T.SubscriptionCriteriaMatchId IS NULL

	
	---------------------------------------------------------------------------------------------------
	--- Explicitly enqueue the last notification for persons that no longer match the criteria
	---------------------------------------------------------------------------------------------------
	INSERT INTO 
		EventNotification (SubscriptionId, PersonUuid, CreatedDate, IsLastNotification)
	SELECT 
		SubscriptionId, PersonUuid, @Now, 1
	FROM 
		@TMP
	WHERE 
			SubscriptionPersonId IS NOT NULL 
		AND SubscriptionCriteriaMatchId IS NULL


	---------------------------------------------------------------------------------------------------
	--- Delete based on inner join, to only affect the records that have been taken into account
	--- This way the procedure is thread safe regarding this table
	--- We still may need to make it thread safe regarding other tables (Subscription, SubscriptionPerson)
	---------------------------------------------------------------------------------------------------
	DELETE 
		SCM
	FROM 
		SubscriptionCriteriaMatch SCM INNER JOIN @TMP TMP
		ON SCM.SubscriptionCriteriaMatchId = TMP.SubscriptionCriteriaMatchId


RETURN 0