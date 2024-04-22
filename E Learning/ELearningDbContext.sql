CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [Discriminator] nvarchar(21) NOT NULL,
    [ImagePath] nvarchar(max) NULL,
    [DisplayName] nvarchar(max) NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Courses] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [Duration] time NOT NULL,
    [Price] float NOT NULL,
    [Language] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Lectures] int NOT NULL,
    [ImagePath] nvarchar(max) NOT NULL,
    [SkillLevel] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Courses_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Assignments] (
    [Id] int NOT NULL IDENTITY,
    [Path] nvarchar(max) NOT NULL,
    [CourseId] int NOT NULL,
    [TimedEntity_Open] datetime2 NOT NULL,
    [TimedEntity_Close] datetime2 NOT NULL,
    [TimedEntity_Grade] float NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Assignments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Assignments_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Exams] (
    [Id] int NOT NULL IDENTITY,
    [TimedEntity_Open] datetime2 NOT NULL,
    [TimedEntity_Close] datetime2 NOT NULL,
    [TimedEntity_Grade] float NOT NULL,
    [CourseId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Exams] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Exams_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [StudentCourses] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [CourseId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_StudentCourses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_StudentCourses_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentCourses_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Attachments] (
    [Id] int NOT NULL IDENTITY,
    [Path] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CourseId] int NOT NULL,
    [AssignmentId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Attachments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Attachments_Assignments_AssignmentId] FOREIGN KEY ([AssignmentId]) REFERENCES [Assignments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Attachments_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [StudentAssignments] (
    [UserId] nvarchar(450) NOT NULL,
    [AssignmentId] int NOT NULL,
    [Mark] float NOT NULL,
    [SubmissionDate] datetime2 NOT NULL,
    CONSTRAINT [PK_StudentAssignments] PRIMARY KEY ([UserId], [AssignmentId]),
    CONSTRAINT [FK_StudentAssignments_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentAssignments_Assignments_AssignmentId] FOREIGN KEY ([AssignmentId]) REFERENCES [Assignments] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [BaseQuestions] (
    [Id] int NOT NULL IDENTITY,
    [RightAnswer] int NOT NULL,
    [ExamId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_BaseQuestions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BaseQuestions_Exams_ExamId] FOREIGN KEY ([ExamId]) REFERENCES [Exams] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [StudentExams] (
    [UserId] nvarchar(450) NOT NULL,
    [ExamId] int NOT NULL,
    [SubmittedAt] datetime2 NOT NULL,
    [Grade] float NOT NULL,
    CONSTRAINT [PK_StudentExams] PRIMARY KEY ([UserId], [ExamId]),
    CONSTRAINT [FK_StudentExams_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentExams_Exams_ExamId] FOREIGN KEY ([ExamId]) REFERENCES [Exams] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Choices] (
    [Id] int NOT NULL IDENTITY,
    [BaseQuestionId] int NOT NULL,
    [Answer] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Choices] PRIMARY KEY ([BaseQuestionId], [Id]),
    CONSTRAINT [FK_Choices_BaseQuestions_BaseQuestionId] FOREIGN KEY ([BaseQuestionId]) REFERENCES [BaseQuestions] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [StudentQuestions] (
    [UserId] nvarchar(450) NOT NULL,
    [BaseQuestionId] int NOT NULL,
    [StudentAnswerId] int NOT NULL,
    CONSTRAINT [PK_StudentQuestions] PRIMARY KEY ([UserId], [BaseQuestionId]),
    CONSTRAINT [FK_StudentQuestions_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentQuestions_BaseQuestions_BaseQuestionId] FOREIGN KEY ([BaseQuestionId]) REFERENCES [BaseQuestions] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO


CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO


CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO


CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO


CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO


CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO


CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO


CREATE INDEX [IX_Assignments_CourseId] ON [Assignments] ([CourseId]);
GO


CREATE INDEX [IX_Attachments_AssignmentId] ON [Attachments] ([AssignmentId]);
GO


CREATE INDEX [IX_Attachments_CourseId] ON [Attachments] ([CourseId]);
GO


CREATE INDEX [IX_BaseQuestions_ExamId] ON [BaseQuestions] ([ExamId]);
GO


CREATE INDEX [IX_Courses_UserId] ON [Courses] ([UserId]);
GO


CREATE INDEX [IX_Exams_CourseId] ON [Exams] ([CourseId]);
GO


CREATE INDEX [IX_StudentAssignments_AssignmentId] ON [StudentAssignments] ([AssignmentId]);
GO


CREATE INDEX [IX_StudentCourses_CourseId] ON [StudentCourses] ([CourseId]);
GO


CREATE INDEX [IX_StudentCourses_UserId] ON [StudentCourses] ([UserId]);
GO


CREATE INDEX [IX_StudentExams_ExamId] ON [StudentExams] ([ExamId]);
GO


CREATE INDEX [IX_StudentQuestions_BaseQuestionId] ON [StudentQuestions] ([BaseQuestionId]);
GO