namespace EdFi.FIF.Core.Models
{
    public class StudentSection
    {
        public string StudentSectionKey { get; set; }
        public string StudentSchoolKey { get; set; }
        public string StudentKey { get; set; }
        public string SectionKey { get; set; }
        public string LocalCourseCode { get; set; }
        public string Subject { get; set; }
        public string CourseTitle { get; set; }
        public string TeacherName { get; set; }
        public string StudentSectionStartDateKey { get; set; }
        public string StudentSectionEndDateKey { get; set; }
        public string SchoolKey { get; set; }
        public string SchoolYear { get; set; }
        public StudentSchool StudentSchool { get; set; }
        public Section Section { get; set; }
    }
}
