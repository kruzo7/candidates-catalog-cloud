CREATE TABLE [dbo].[CandidatesAddresses] (
    [CandidateAddressId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidateAddressId] ASC),
    [CandidateId]        UNIQUEIDENTIFIER NOT NULL UNIQUE,
    [CountryId]          UNIQUEIDENTIFIER NOT NULL,
    [CityName]           VARCHAR (500)    NOT NULL,
    [StreetName]         VARCHAR (500)    NOT NULL,
    [StreetNumber]       VARCHAR (50)     NOT NULL,
    [PostCode]           VARCHAR (50)     NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL,
    CONSTRAINT [FK_CandidatesAddresses_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([CandidateId]),
    CONSTRAINT [FK_CandidatesAddresses_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([CountryId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_CandidatesAddresses_1]
    ON [dbo].[CandidatesAddresses]([CandidateAddressId] ASC);
GO

