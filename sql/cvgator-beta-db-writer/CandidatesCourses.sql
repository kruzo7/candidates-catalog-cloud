CREATE TABLE [dbo].[CandidatesCourses] (
    [CandidateCourseId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CandidateCourseId] ASC),
    [CandidateId]      UNIQUEIDENTIFIER NOT NULL,
    [CourseId]          UNIQUEIDENTIFIER NOT NULL,
    [StartDate]        DATE              NOT NULL,
    [EndDate]          DATE              NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL,
    CONSTRAINT [FK_CandidatesCourses_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([CandidateId]),
    CONSTRAINT [FK_CandidatesCourses_Courses] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([CourseId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_CandidatesCourses_1]
    ON [dbo].[CandidatesCourses]([CandidateCourseId] ASC);
GO

