/****** Object:  ForeignKey [FK_BirthdateEventNotification_EventNotification]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BirthdateEventNotification_EventNotification]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateEventNotification]'))
ALTER TABLE [dbo].[BirthdateEventNotification] DROP CONSTRAINT [FK_BirthdateEventNotification_EventNotification]
GO
/****** Object:  ForeignKey [FK_BirthdateSubscription_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BirthdateSubscription_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]'))
ALTER TABLE [dbo].[BirthdateSubscription] DROP CONSTRAINT [FK_BirthdateSubscription_Subscription]
GO
/****** Object:  ForeignKey [FK_Channel_ChannelType]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Channel_ChannelType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Channel]'))
ALTER TABLE [dbo].[Channel] DROP CONSTRAINT [FK_Channel_ChannelType]
GO
/****** Object:  ForeignKey [FK_Channel_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Channel_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[Channel]'))
ALTER TABLE [dbo].[Channel] DROP CONSTRAINT [FK_Channel_Subscription]
GO
/****** Object:  ForeignKey [FK_DataSubscription_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DataSubscription_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[DataSubscription]'))
ALTER TABLE [dbo].[DataSubscription] DROP CONSTRAINT [FK_DataSubscription_Subscription]
GO
/****** Object:  ForeignKey [FK_EventNotification_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EventNotification_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventNotification]'))
ALTER TABLE [dbo].[EventNotification] DROP CONSTRAINT [FK_EventNotification_Subscription]
GO
/****** Object:  ForeignKey [FK_Subscription_SubscriptionType]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Subscription_SubscriptionType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Subscription]'))
ALTER TABLE [dbo].[Subscription] DROP CONSTRAINT [FK_Subscription_SubscriptionType]
GO
/****** Object:  ForeignKey [FK_SubscriptionPerson_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubscriptionPerson_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubscriptionPerson]'))
ALTER TABLE [dbo].[SubscriptionPerson] DROP CONSTRAINT [FK_SubscriptionPerson_Subscription]
GO
/****** Object:  Default [DF_BirthdateSubscription_SubscriptionId]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_BirthdateSubscription_SubscriptionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]'))
Begin
ALTER TABLE [dbo].[BirthdateSubscription] DROP CONSTRAINT [DF_BirthdateSubscription_SubscriptionId]

End
GO
/****** Object:  Default [DF_BirthdateSubscription_OffsetDays]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_BirthdateSubscription_OffsetDays]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]'))
Begin
ALTER TABLE [dbo].[BirthdateSubscription] DROP CONSTRAINT [DF_BirthdateSubscription_OffsetDays]

End
GO
/****** Object:  Default [DF_Channel_ChannelId]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Channel_ChannelId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Channel]'))
Begin
ALTER TABLE [dbo].[Channel] DROP CONSTRAINT [DF_Channel_ChannelId]

End
GO
/****** Object:  Default [DF_EventNotification_EventNotificationId]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EventNotification_EventNotificationId]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventNotification]'))
Begin
ALTER TABLE [dbo].[EventNotification] DROP CONSTRAINT [DF_EventNotification_EventNotificationId]

End
GO
/****** Object:  Default [DF_Subscription_SubscriptionId]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Subscription_SubscriptionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Subscription]'))
Begin
ALTER TABLE [dbo].[Subscription] DROP CONSTRAINT [DF_Subscription_SubscriptionId]

End
GO
/****** Object:  Default [DF_Subscription_IsForAllPersons]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Subscription_IsForAllPersons]') AND parent_object_id = OBJECT_ID(N'[dbo].[Subscription]'))
Begin
ALTER TABLE [dbo].[Subscription] DROP CONSTRAINT [DF_Subscription_IsForAllPersons]

End
GO
/****** Object:  Default [DF_SubscriptionPerson_SubscriptionPersonId]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_SubscriptionPerson_SubscriptionPersonId]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubscriptionPerson]'))
Begin
ALTER TABLE [dbo].[SubscriptionPerson] DROP CONSTRAINT [DF_SubscriptionPerson_SubscriptionPersonId]

End
GO
/****** Object:  StoredProcedure [dbo].[EnqueueDataChangeEventNotifications]    Script Date: 02/13/2011 17:59:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EnqueueDataChangeEventNotifications]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EnqueueDataChangeEventNotifications]
GO
/****** Object:  StoredProcedure [dbo].[EnqueueBirthdateEventNotifications]    Script Date: 02/13/2011 17:59:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EnqueueBirthdateEventNotifications]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EnqueueBirthdateEventNotifications]
GO
/****** Object:  StoredProcedure [dbo].[InsertChangeNotificationData]    Script Date: 02/13/2011 17:59:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertChangeNotificationData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertChangeNotificationData]
GO
/****** Object:  Table [dbo].[BirthdateEventNotification]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BirthdateEventNotification]') AND type in (N'U'))
DROP TABLE [dbo].[BirthdateEventNotification]
GO
/****** Object:  Table [dbo].[DataSubscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataSubscription]') AND type in (N'U'))
DROP TABLE [dbo].[DataSubscription]
GO
/****** Object:  Table [dbo].[BirthdateSubscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]') AND type in (N'U'))
DROP TABLE [dbo].[BirthdateSubscription]
GO
/****** Object:  Table [dbo].[SubscriptionPerson]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubscriptionPerson]') AND type in (N'U'))
DROP TABLE [dbo].[SubscriptionPerson]
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel]') AND type in (N'U'))
DROP TABLE [dbo].[Channel]
GO
/****** Object:  Table [dbo].[EventNotification]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventNotification]') AND type in (N'U'))
DROP TABLE [dbo].[EventNotification]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subscription]') AND type in (N'U'))
DROP TABLE [dbo].[Subscription]
GO
/****** Object:  Table [dbo].[SubscriptionType]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubscriptionType]') AND type in (N'U'))
DROP TABLE [dbo].[SubscriptionType]
GO
/****** Object:  Table [dbo].[PersonBirthdate]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonBirthdate]') AND type in (N'U'))
DROP TABLE [dbo].[PersonBirthdate]
GO
/****** Object:  Table [dbo].[DataChangeEvent]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataChangeEvent]') AND type in (N'U'))
DROP TABLE [dbo].[DataChangeEvent]
GO
/****** Object:  UserDefinedFunction [dbo].[IsBirthdateEvent]    Script Date: 02/13/2011 17:59:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsBirthdateEvent]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[IsBirthdateEvent]
GO
/****** Object:  Table [dbo].[ChannelType]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChannelType]') AND type in (N'U'))
DROP TABLE [dbo].[ChannelType]
GO
/****** Object:  Table [dbo].[ChannelType]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChannelType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChannelType](
	[ChannelTypeId] [int] NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ChannelType] PRIMARY KEY CLUSTERED 
(
	[ChannelTypeId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  UserDefinedFunction [dbo].[IsBirthdateEvent]    Script Date: 02/13/2011 17:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsBirthdateEvent]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE Function [dbo].[IsBirthdateEvent]
(
		@Now DateTime,
		@BirthDate DateTime,
		@AgeYears INT,
		@PriorDays INT
)
RETURNS BIT
AS
BEGIN
	IF
	(	
		-- Exact age match
		@AgeYears IS NOT NULL 
		AND dateadd (day, @PriorDays, @Now) = dateadd(year, @AgeYears, @BirthDate)
	)
	OR
	(
		-- Any age match
		@AgeYears IS NULL 
		AND DATEPART(DAY,DATEADD(day, @PriorDays, @Now)) = DATEPART(DAY,@BirthDate)
		AND DATEPART(MONTH,DATEADD(day, @PriorDays, @Now)) = DATEPART(MONTH,@BirthDate)
	)
		RETURN 1
		
	RETURN 0
END

' 
END
GO
/****** Object:  Table [dbo].[DataChangeEvent]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataChangeEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DataChangeEvent](
	[DataChangeEventId] [uniqueidentifier] NOT NULL,
	[PersonUuid] [uniqueidentifier] NOT NULL,
	[PersonRegistrationId] [uniqueidentifier] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[ReceivedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DataChangeEvent] PRIMARY KEY CLUSTERED 
(
	[DataChangeEventId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[PersonBirthdate]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonBirthdate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PersonBirthdate](
	[PersonUuid] [uniqueidentifier] NOT NULL,
	[Birthdate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonBirthdate] PRIMARY KEY CLUSTERED 
(
	[PersonUuid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[SubscriptionType]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubscriptionType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubscriptionType](
	[SubscriptionTypeId] [int] NOT NULL,
	[TypeName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_SubscriptionType] PRIMARY KEY CLUSTERED 
(
	[SubscriptionTypeId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subscription]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Subscription](
	[SubscriptionId] [uniqueidentifier] NOT NULL,
	[SubscriptionTypeId] [int] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[IsForAllPersons] [bit] NOT NULL,
	[Criteria] [XML] NULL,
	[Created] [Datetime] NOT NULL,
	[Deactivated] [Datetime NULL] NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[EventNotification]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventNotification]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventNotification](
	[EventNotificationId] [uniqueidentifier] NOT NULL,
	[SubscriptionId] [uniqueidentifier] NOT NULL,
	[PersonUuid] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[NotificationDate] [datetime] NULL,
	[Succeeded] [bit] NULL,
	[IsLastNotification] [bit] NULL,
 CONSTRAINT [PK_EventNotification] PRIMARY KEY CLUSTERED 
(
	[EventNotificationId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Channel](
	[ChannelId] [uniqueidentifier] NOT NULL,
	[ChannelTypeId] [int] NOT NULL,
	[SubscriptionId] [uniqueidentifier] NOT NULL,
	[Url] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Channel] PRIMARY KEY CLUSTERED 
(
	[ChannelId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF),
 CONSTRAINT [IX_Channel] UNIQUE NONCLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[SubscriptionPerson]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubscriptionPerson]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubscriptionPerson](
	[SubscriptionPersonId] [uniqueidentifier] NOT NULL,
	[SubscriptionId] [uniqueidentifier] NULL,
	[PersonUuid] [uniqueidentifier] NULL,
	[Created] [Datetime] NOT NULL,
	[Removed] [Datetime] NULL,
 CONSTRAINT [PK_SubscriptionPerson] PRIMARY KEY CLUSTERED 
(
	[SubscriptionPersonId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF),
 CONSTRAINT [IX_SubscriptionPerson] UNIQUE NONCLUSTERED 
(
	[SubscriptionId] ASC,
	[PersonUuid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[BirthdateSubscription]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BirthdateSubscription](
	[SubscriptionId] [uniqueidentifier] NOT NULL,
	[AgeYears] [int] NULL,
	[PriorDays] [int] NOT NULL,
 CONSTRAINT [PK_BirthdateSubscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[DataSubscription]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataSubscription]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DataSubscription](
	[SubscriptionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DataSubscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[BirthdateEventNotification]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BirthdateEventNotification]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BirthdateEventNotification](
	[EventNotificationId] [uniqueidentifier] NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_BirthdateEventNotification] PRIMARY KEY CLUSTERED 
(
	[EventNotificationId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertChangeNotificationData]    Script Date: 02/13/2011 17:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertChangeNotificationData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE Procedure [dbo].[InsertChangeNotificationData]
(
	@SubscriptionId UNIQUEIDENTIFIER,
	@Today DATETIME,
	@LastTime DATETIME
)

AS
	DECLARE @NotificationId UNIQUEIDENTIFIER
	DECLARE @IsForAllPersons BIT
	
	-- Select subscription data
	SELECT @IsForAllPersons= IsForAllPersons
	FROM Subscription AS S 
	INNER JOIN DataSubscription AS DS ON S.SubscriptionId = DS.SubscriptionId
	WHERE S.SubscriptionId = @SubscriptionId
	
	-- Use this table to store temporary data
	CREATE TABLE #Person (NotificationPersonId UNIQUEIDENTIFIER DEFAULT NEWID(), PersonId UNIQUEIDENTIFIER)
	
	-- Search for persons that could possible fire the notification
	INSERT INTO #Person (PersonId)
	SELECT P.PersonId
	FROM Person AS P
	LEFT OUTER JOIN SubscriptionPerson AS SP ON P.PersonId = SP.PersonId
	WHERE 
	(
		@IsForAllPersons = 1 OR SP.SubscriptionId = @SubscriptionId
	)
	AND
	(
		dbo.IsDataChangeEvent(P.PersonId, @Today, @LastTime) = 1
	)
	
	
	IF EXISTS (SELECT TOP 1 * FROM #Person) -- If persons are found
	BEGIN
		-- Insert data into physical tables
		SET @NotificationID = NEWID()
		
		INSERT INTO Notification (NotificationId, SubscriptionId, NotificationDate)
		VALUES (@NotificationId, @SubscriptionId, @Today)
		
		INSERT INTO NotificationPerson (NotificationId, NotificationPersonId, PersonId)
		SELECT @NotificationId, NotificationPersonId, PersonId
		FROM #Person		
		
	END
	
	-- Finally, return the new Notification object
	SELECT * 
	FROM Notification 
	WHERE NotificationId = @NotificationId

' 
END
GO
/****** Object:  StoredProcedure [dbo].[EnqueueBirthdateEventNotifications]    Script Date: 02/13/2011 17:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EnqueueBirthdateEventNotifications]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE Procedure [dbo].[EnqueueBirthdateEventNotifications]
(
	@SubscriptionId uniqueidentifier,
	@Today DateTime
)

AS
	
	DECLARE @NotificationId UNIQUEIDENTIFIER
	
	DECLARE @AgeYears INT
	DECLARE @PriorDays INT
	DECLARE @IsForAllPersons BIT
	
	-- Get subscription parameters
	SELECT @AgeYears = AgeYears, @PriorDays=PriorDays, @IsForAllPersons= IsForAllPersons
	FROM Subscription AS S 
	INNER JOIN BirthdateSubscription AS BDS ON S.SubscriptionId = BDS.SubscriptionId
	WHERE S.SubscriptionId = @SubscriptionId
	
	-- Temp table to hold persons
	CREATE TABLE #Person (EventNotificationId UNIQUEIDENTIFIER DEFAULT NEWID(), PersonUuid UNIQUEIDENTIFIER, Birthdate DATETIME, Age INT)
		
	
	-- Search  for persons that match the subscription rule
	INSERT INTO #Person (PersonUuid, Birthdate, Age)
	SELECT PB.PersonUuid, PB.BirthDate, DATEDIFF(YEAR, PB.Birthdate, DATEADD(day, @PriorDays, @Today))	
	FROM PersonBirthdate AS PB
	LEFT OUTER JOIN SubscriptionPerson AS SP ON PB.PersonUuid = SP.PersonUuid
	WHERE 
	(
		@IsForAllPersons = 1 OR SP.SubscriptionId = @SubscriptionId
	)
	AND
	(
		dbo.IsBirthdateEvent(@Today, PB.BirthDate, @AgeYears, @PriorDays) = 1
	)
	
	
	INSERT INTO EventNotification (EventNotificationId, SubscriptionId, PersonUUID, CreatedDate)
	SELECT EventNotificationId, @SubscriptionId, PersonUuid, @Today
	FROM #Person
		
	INSERT INTO BirthdateEventNotification (EventNotificationId, Age)
	SELECT EventNotificationId, Age
	FROM #Person
		
	

' 
END
GO
/****** Object:  StoredProcedure [dbo].[EnqueueDataChangeEventNotifications]    Script Date: 02/13/2011 17:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EnqueueDataChangeEventNotifications]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE Procedure [dbo].[EnqueueDataChangeEventNotifications]
(
		--@StartDate DateTime,
		--@EndDate DateTime,
		@Now DateTime,
		@SubscriptionTypeId Int
)


AS
		-- Subscriptions (that ARE NOT deactivated) for specific persons that deactivated
		INSERT INTO EventNotification (SubscriptionId, PersonUUID, CreatedDate)
		SELECT S.SubscriptionId, DCE.PersonUuid, @Now
		FROM DataChangeEvent AS DCE
		INNER JOIN SubscriptionPerson AS SP ON SP.PersonUuid = DCE.PersonUuid
		INNER JOIN Subscription AS S ON S.SubscriptionId = SP.SubscriptionId
		WHERE 
			--DCE.ReceivedDate BETWEEN @StartDate AND @EndDate
			S.IsForAllPersons = 0
			AND S.SubscriptionTypeId = @SubscriptionTypeId
			-- We test if the subscription has been deactivated
			AND S.Deactivated IS NULL
		
		-- Subscriptions (that ARE deactivated) for specific persons
		INSERT INTO EventNotification (SubscriptionId, PersonUUID, CreatedDate, IsLastNotification)
		SELECT S.SubscriptionId, DCE.PersonUuid, @Now, 1
		FROM DataChangeEvent AS DCE
		INNER JOIN SubscriptionPerson AS SP ON SP.PersonUuid = DCE.PersonUuid
		INNER JOIN Subscription AS S ON S.SubscriptionId = SP.SubscriptionId
		WHERE 
			--DCE.ReceivedDate BETWEEN @StartDate AND @EndDate
			S.IsForAllPersons = 0
			AND S.SubscriptionTypeId = @SubscriptionTypeId
			-- We test if the subscription has been deactivated
			AND S.Deactivated IS NOT NULL
		
		-- Subscriptions for all persons
		INSERT INTO EventNotification (SubscriptionId, PersonUUID, CreatedDate)
		SELECT S.SubscriptionId, DCE.PersonUuid, @Now
		FROM DataChangeEvent AS DCE,	Subscription AS S	
		WHERE 
			--DCE.ReceivedDate BETWEEN @StartDate AND @EndDate
			S.IsForAllPersons = 1
			AND S.SubscriptionTypeId = @SubscriptionTypeId
' 
END
GO
/****** Object:  Default [DF_BirthdateSubscription_SubscriptionId]    Script Date: 02/13/2011 17:59:04 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_BirthdateSubscription_SubscriptionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]'))
Begin
ALTER TABLE [dbo].[BirthdateSubscription] ADD  CONSTRAINT [DF_BirthdateSubscription_SubscriptionId]  DEFAULT (newid()) FOR [SubscriptionId]

End
GO
/****** Object:  Default [DF_BirthdateSubscription_OffsetDays]    Script Date: 02/13/2011 17:59:04 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_BirthdateSubscription_OffsetDays]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]'))
Begin
ALTER TABLE [dbo].[BirthdateSubscription] ADD  CONSTRAINT [DF_BirthdateSubscription_OffsetDays]  DEFAULT ((0)) FOR [PriorDays]

End
GO
/****** Object:  Default [DF_Channel_ChannelId]    Script Date: 02/13/2011 17:59:04 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Channel_ChannelId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Channel]'))
Begin
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_ChannelId]  DEFAULT (newid()) FOR [ChannelId]

End
GO
/****** Object:  Default [DF_EventNotification_EventNotificationId]    Script Date: 02/13/2011 17:59:04 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EventNotification_EventNotificationId]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventNotification]'))
Begin
ALTER TABLE [dbo].[EventNotification] ADD  CONSTRAINT [DF_EventNotification_EventNotificationId]  DEFAULT (newid()) FOR [EventNotificationId]

End
GO
/****** Object:  Default [DF_Subscription_SubscriptionId]    Script Date: 02/13/2011 17:59:04 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Subscription_SubscriptionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Subscription]'))
Begin
ALTER TABLE [dbo].[Subscription] ADD  CONSTRAINT [DF_Subscription_SubscriptionId]  DEFAULT (newid()) FOR [SubscriptionId]

End
GO
/****** Object:  Default [DF_Subscription_IsForAllPersons]    Script Date: 02/13/2011 17:59:04 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Subscription_IsForAllPersons]') AND parent_object_id = OBJECT_ID(N'[dbo].[Subscription]'))
Begin
ALTER TABLE [dbo].[Subscription] ADD  CONSTRAINT [DF_Subscription_IsForAllPersons]  DEFAULT ((1)) FOR [IsForAllPersons]

End
GO
/****** Object:  Default [DF_SubscriptionPerson_SubscriptionPersonId]    Script Date: 02/13/2011 17:59:04 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_SubscriptionPerson_SubscriptionPersonId]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubscriptionPerson]'))
Begin
ALTER TABLE [dbo].[SubscriptionPerson] ADD  CONSTRAINT [DF_SubscriptionPerson_SubscriptionPersonId]  DEFAULT (newid()) FOR [SubscriptionPersonId]

End
GO
/****** Object:  ForeignKey [FK_BirthdateEventNotification_EventNotification]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BirthdateEventNotification_EventNotification]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateEventNotification]'))
ALTER TABLE [dbo].[BirthdateEventNotification]  WITH CHECK ADD  CONSTRAINT [FK_BirthdateEventNotification_EventNotification] FOREIGN KEY([EventNotificationId])
REFERENCES [dbo].[EventNotification] ([EventNotificationId])
GO
ALTER TABLE [dbo].[BirthdateEventNotification] CHECK CONSTRAINT [FK_BirthdateEventNotification_EventNotification]
GO
/****** Object:  ForeignKey [FK_BirthdateSubscription_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BirthdateSubscription_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[BirthdateSubscription]'))
ALTER TABLE [dbo].[BirthdateSubscription]  WITH CHECK ADD  CONSTRAINT [FK_BirthdateSubscription_Subscription] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([SubscriptionId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BirthdateSubscription] CHECK CONSTRAINT [FK_BirthdateSubscription_Subscription]
GO
/****** Object:  ForeignKey [FK_Channel_ChannelType]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Channel_ChannelType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Channel]'))
ALTER TABLE [dbo].[Channel]  WITH CHECK ADD  CONSTRAINT [FK_Channel_ChannelType] FOREIGN KEY([ChannelTypeId])
REFERENCES [dbo].[ChannelType] ([ChannelTypeId])
GO
ALTER TABLE [dbo].[Channel] CHECK CONSTRAINT [FK_Channel_ChannelType]
GO
/****** Object:  ForeignKey [FK_Channel_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Channel_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[Channel]'))
ALTER TABLE [dbo].[Channel]  WITH CHECK ADD  CONSTRAINT [FK_Channel_Subscription] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([SubscriptionId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Channel] CHECK CONSTRAINT [FK_Channel_Subscription]
GO
/****** Object:  ForeignKey [FK_DataSubscription_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DataSubscription_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[DataSubscription]'))
ALTER TABLE [dbo].[DataSubscription]  WITH CHECK ADD  CONSTRAINT [FK_DataSubscription_Subscription] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([SubscriptionId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DataSubscription] CHECK CONSTRAINT [FK_DataSubscription_Subscription]
GO
/****** Object:  ForeignKey [FK_EventNotification_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EventNotification_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventNotification]'))
ALTER TABLE [dbo].[EventNotification]  WITH CHECK ADD  CONSTRAINT [FK_EventNotification_Subscription] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([SubscriptionId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventNotification] CHECK CONSTRAINT [FK_EventNotification_Subscription]
GO
/****** Object:  ForeignKey [FK_Subscription_SubscriptionType]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Subscription_SubscriptionType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Subscription]'))
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_SubscriptionType] FOREIGN KEY([SubscriptionTypeId])
REFERENCES [dbo].[SubscriptionType] ([SubscriptionTypeId])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_SubscriptionType]
GO
/****** Object:  ForeignKey [FK_SubscriptionPerson_Subscription]    Script Date: 02/13/2011 17:59:04 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubscriptionPerson_Subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubscriptionPerson]'))
ALTER TABLE [dbo].[SubscriptionPerson]  WITH CHECK ADD  CONSTRAINT [FK_SubscriptionPerson_Subscription] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([SubscriptionId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubscriptionPerson] CHECK CONSTRAINT [FK_SubscriptionPerson_Subscription]
GO
