CREATE TABLE [dbo].[CandidatesSchools] (
    [CandidateSchoolId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidateSchoolId] ASC),
    [CandidateId]         UNIQUEIDENTIFIER NOT NULL,
    [SchoolId]            UNIQUEIDENTIFIER NOT NULL,
    [StartDate]           DATE             NOT NULL,
    [EndDate]             DATE             NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL,
    CONSTRAINT [FK_CandidatesSchools_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([CandidateId]),
    CONSTRAINT [FK_CandidatesSchools_Schools] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([SchoolId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_CandidatesSchools_1]
    ON [dbo].[CandidatesSchools]([CandidateSchoolId] ASC);
GO

