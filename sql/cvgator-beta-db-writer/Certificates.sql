CREATE TABLE [dbo].[Certificates] (
    [CertificateId]   UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CertificateId] ASC),
    [CertificateName] VARCHAR (1000)   NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_Certificates_1]
    ON [dbo].[Certificates]([CertificateId] ASC);
GO

