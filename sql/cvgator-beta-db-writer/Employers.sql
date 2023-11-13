CREATE TABLE [dbo].[Employers] (
    [EmployerId]   UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([EmployerId] ASC),
    [EmployerName] VARCHAR (1000)   NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL
);

GO
CREATE NONCLUSTERED INDEX [Index_Employers_1]
    ON [dbo].[Employers]([EmployerId] ASC);
GO

