CREATE TABLE [dbo].[Countries] (
    [CountryId]   UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CountryId] ASC),
    [CountryName] VARCHAR (500)    NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_Countries_1]
    ON [dbo].[Countries]([CountryId] ASC);
GO

