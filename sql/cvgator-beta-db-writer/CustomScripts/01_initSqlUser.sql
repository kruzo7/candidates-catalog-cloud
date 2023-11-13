
CREATE USER cvgatorbetaadmin
	FOR LOGIN cvgatorbetaadmin	
GO

EXEC sp_addrolemember N'db_datareader', N'cvgatorbetaadmin'
GO

EXEC sp_addrolemember N'db_datawriter', N'cvgatorbetaadmin'
GO

END