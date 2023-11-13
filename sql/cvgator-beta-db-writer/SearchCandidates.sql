CREATE TABLE [dbo].[SearchCandidates]
(
  [CandidateId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED ([CandidateId] ASC),
  [CandidateFirstName] VARCHAR (500) NOT NULL,
  [CandidateLastName] VARCHAR (500) NOT NULL,
  [BirthDate] DATE NOT NULL,
  [CandidateCity] VARCHAR (500) NOT Null,
  [CandidateCategories] VARCHAR (MAX) NOT Null,
  [CandidateSchools] VARCHAR (MAX) Null,
  [CandidateCertificates] VARCHAR (MAX) Null,
  [CandidateCourses] VARCHAR (MAX) Null,
  [CandidateEmployers] VARCHAR (MAX) Null,
  [CandidateActualEmployers] VARCHAR (4000) Null,
  [AudCreateOn] DATETIME NOT NULL,
  [AudModifyOn] DATETIME NOT NULL,
  [AudCreateBy] VARCHAR (250) NOT NULL,
  [AudModifyBy] VARCHAR (250) NOT NULL
)

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_SearchCandidates_1]
    ON [dbo].[SearchCandidates]([CandidateId] ASC);
GO
