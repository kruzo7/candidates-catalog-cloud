CREATE TABLE [dbo].[CandidatesCategories] (
    [CandidateCategoryId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidateCategoryId] ASC),
    [CategoryId]          UNIQUEIDENTIFIER NOT NULL,
    [CandidateId]         UNIQUEIDENTIFIER NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL,
    CONSTRAINT [FK_CandidatesCategories_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([CandidateId]),
    CONSTRAINT [FK_CandidatesCategories_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_CandidatesCategories_1]
    ON [dbo].[CandidatesCategories]([CandidateCategoryId] ASC);
GO

