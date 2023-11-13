--For Azure Cognitive Search
ALTER DATABASE [CVGator-beta-DB-Writer]
SET CHANGE_TRACKING = ON  
(CHANGE_RETENTION = 1 DAYS, AUTO_CLEANUP = ON) 
GO

ALTER TABLE [CVGator-beta-DB-Writer].[dbo].[SearchCandidates]
ENABLE CHANGE_TRACKING  
WITH (TRACK_COLUMNS_UPDATED = ON)  
GO

GRANT VIEW CHANGE TRACKING ON [dbo].[SearchCandidates] TO [cvgatorbetaadmin]
GO