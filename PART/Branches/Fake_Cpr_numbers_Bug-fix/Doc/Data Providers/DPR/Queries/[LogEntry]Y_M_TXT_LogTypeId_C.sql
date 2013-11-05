SELECT Y,M,LogTypeId,TXT,COUNT(*) AS C FROM (
	SELECT DATEPART(YEAR,LogDate) AS Y, DATEPART(MONTH,LogDate) AS M, LogTypeId, SUBSTRING(Text,1,36) AS TXT 
	FROM CprBroker.dbo.LogEntry
) AS sss
GROUP BY Y,M,TXT,LogTypeId
ORDER BY Y,M,TXT,LogTypeId
