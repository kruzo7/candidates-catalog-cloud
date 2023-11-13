CREATE TABLE [dbo].[Candidates] (
    [CandidateId]        UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidateId] ASC),
    [CandidateFirstName] VARCHAR (500)    NOT NULL,
    [CandidateLastName]  VARCHAR (500)    NOT NULL,
    [BirthDate]          DATE             NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_Candidates_1]
    ON [dbo].[Candidates]([CandidateId] ASC);
GO

