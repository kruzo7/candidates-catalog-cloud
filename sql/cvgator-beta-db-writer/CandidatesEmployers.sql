CREATE TABLE [dbo].[CandidatesEmployers] (
    [CandidatesEmployersId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidatesEmployersId] ASC),
    [CandidateId]           UNIQUEIDENTIFIER NOT NULL,
    [EmployerId]            UNIQUEIDENTIFIER NOT NULL,
    [StartDate]             DATE             NOT NULL,
    [EndDate]               DATE             NULL,
    [EmploymentStatus]      SMALLINT         NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL,
    CONSTRAINT [FK_CandidatesEmployers_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([CandidateId]),
    CONSTRAINT [FK_CandidatesEmployers_Employers] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employers] ([EmployerId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_CandidatesEmployers_1]
    ON [dbo].[CandidatesEmployers]([CandidatesEmployersId] ASC);
GO

