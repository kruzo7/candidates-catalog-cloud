CREATE TABLE [dbo].[Categories] (
    [CategoryId]   UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    [CategoryName] VARCHAR (500)    NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_Categories_1]
    ON [dbo].[Categories]([CategoryId] ASC);
GO

