CREATE TABLE [dbo].[Files]
(
    [FileId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([FileId] ASC),
    [CandidateId] UNIQUEIDENTIFIER NOT NULL,
    [FileName] VARCHAR (1000),
    [CautionUserFileName] VARCHAR(1000),
    [FileResource] INT,
    [FileType] INT,
    [MimeContentType] VARCHAR(1000),
    [UploadFileStatus] INT,
    [Message] VARCHAR(4000),
    [Url] VARCHAR(2000),
    [BlobUrl] VARCHAR(2000),
    [AudCreateOn] DATETIME NOT NULL,
    [AudModifyOn] DATETIME NOT NULL,
    [AudCreateBy] VARCHAR (250) NOT NULL,
    [AudModifyBy] VARCHAR (250) NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_Files_1]
    ON [dbo].[Files]([FileId] ASC);
GO

