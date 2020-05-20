CREATE TABLE fif.StudentSchool (
    StudentSchoolKey nvarchar(45) NOT NULL,
    StudentKey nvarchar(32) NOT NULL,
    SchoolKey nvarchar(30) NOT NULL,
    SchoolYear nvarchar(30) NULL,
    StudentFirstName nvarchar(75) NOT NULL,
    StudentMiddleName nvarchar(75) NULL,
    StudentLastName nvarchar(75) NULL,
    EnrollmentDateKey nvarchar(30) NULL,
    GradeLevel nvarchar(50) NOT NULL,
    LimitedEnglishProficiency nvarchar(50) NULL,
    IsHispanic bit NOT NULL,
    Sex nvarchar(50) NOT NULL,
    CONSTRAINT PK_StudentSchoolKey PRIMARY KEY (StudentSchoolKey)
);

GO

CREATE TABLE fif.ContactPerson (
    UniqueKey nvarchar(65) NOT NULL,
    ContactPersonKey nvarchar(32) NOT NULL,
    StudentKey nvarchar(32) NOT NULL,
    ContactFirstName nvarchar(75) NOT NULL,
    ContactLastName nvarchar(75) NOT NULL,
    RelationshipToStudent nvarchar(50) NOT NULL,
    StreetNumberName nvarchar(150) NOT NULL,
    ApartmentRoomSuiteNumber nvarchar(50) NULL,
    State nvarchar(50) NOT NULL,
    PostalCode nvarchar(17) NOT NULL,
    PhoneNumber nvarchar(24) NULL,
    PrimaryEmailAddress nvarchar(128) NULL,
    IsPrimaryContact bit NULL,
    CONSTRAINT PK_UniqueKey PRIMARY KEY (UniqueKey)
);

GO

CREATE TABLE fif.StudentContact (
    ContactKey nvarchar(65) NOT NULL,
    StudentSchoolKey nvarchar(45) NOT NULL,
    CONSTRAINT PK_UniqueKey_StudentSchoolKey PRIMARY KEY (ContactKey, StudentSchoolKey),
    CONSTRAINT FK_ContactPerson_ContactKey_UniqueKey FOREIGN KEY (ContactKey) REFERENCES fif.ContactPerson (UniqueKey),
    CONSTRAINT FK_ContactPerson_StudentSchoolKey_StudentSchoolKey FOREIGN KEY (StudentSchoolKey) REFERENCES fif.StudentSchool (StudentSchoolKey)
);

GO

CREATE TABLE fif.StudentSection (
    StudentSectionKey nvarchar(60) NOT NULL,
    StudentKey nvarchar(32) NOT NULL,
    SectionKey nvarchar(60) NULL,
    LocalCourseCode nvarchar(60) NULL,
    Subject nvarchar(60) NOT NULL,
    CourseTitle nvarchar(60) NOT NULL,
    TeacherName nvarchar(max) NULL,
    StudentSectionStartDateKey nvarchar(30) NULL,
    StudentSectionEndDateKey nvarchar(30) NULL,
    SchoolKey nvarchar(30) NULL,
    SchoolYear nvarchar(30) NULL,
    CONSTRAINT PK_StudentSectionKey PRIMARY KEY (StudentSectionKey)

    --- Since StudentKey is not a primary key in fif.StudentSchool and it doesn't have any sort of unique index, we can't create this reference:
    --CONSTRAINT FK_StudentSection_StudentKey_StudentKey FOREIGN KEY (StudentKey,SchoolKey,SchoolYear) REFERENCES fif.StudentSchool (StudentKey,SchoolKey,SchoolYear)
);

GO