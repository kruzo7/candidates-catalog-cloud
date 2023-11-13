CREATE TABLE [dbo].[CandidatesCertificates] (
    [CandidateCertificateId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidateCertificateId] ASC),
    [CandidateId]            UNIQUEIDENTIFIER NOT NULL,
    [CertificateId]          UNIQUEIDENTIFIER NOT NULL,
    [StartDate]              DATE             NOT NULL,
    [EndDate]                DATE             NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL,
    CONSTRAINT [FK_CandidatesCertificates_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([CandidateId]),
    CONSTRAINT [FK_CandidatesCertificates_Certificates] FOREIGN KEY ([CertificateId]) REFERENCES [dbo].[Certificates] ([CertificateId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_CandidatesCertificates_1]
    ON [dbo].[CandidatesCertificates]([CandidateCertificateId] ASC);
GO

