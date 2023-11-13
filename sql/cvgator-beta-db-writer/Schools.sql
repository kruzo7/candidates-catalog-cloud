CREATE TABLE [dbo].[Schools] (
    [SchoolId]   UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([SchoolId] ASC),
    [SchoolName] VARCHAR (1000)    NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_Schools_1]
    ON [dbo].[Schools]([SchoolId] ASC);
GO

