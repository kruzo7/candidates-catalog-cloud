CREATE TABLE [dbo].[Courses] (
    [CourseId]   UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY CLUSTERED ([CourseId] ASC),
    [CourseName] VARCHAR (1000)   NOT NULL,
    [AudCreateOn]        DATETIME         NOT NULL,
    [AudModifyOn]        DATETIME         NOT NULL,
    [AudCreateBy]        VARCHAR (250)    NOT NULL,
    [AudModifyBy]        VARCHAR (250)    NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Index_Courses_1]
    ON [dbo].[Courses]([CourseId] ASC);
GO

