CREATE TABLE [dbo].[CandidatesFiles]
(
    [CandidateFileId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidateFileId] ASC),
    [CandidateId] UNIQUEIDENTIFIER NOT NULL,
    [FileId] UNIQUEIDENTIFIER NOT NULL,
    [AudCreateOn] DATETIME NOT NULL,
    [AudModifyOn] DATETIME NOT NULL,
    [AudCreateBy] VARCHAR (250) NOT NULL,
    [AudModifyBy] VARCHAR (250) NOT NULL,
    CONSTRAINT [FK_CandidatesFiles_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([CandidateId]),
    CONSTRAINT [FK_CandidatesFiles_Files] FOREIGN KEY ([FileId]) REFERENCES [dbo].[Files] ([FileId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_CandidatesFiles_1]
    ON [dbo].[CandidatesFiles]([CandidateFileId] ASC);
GO

