using System.Collections.Generic;

namespace EdFi.FIF.Core.Models
{
    public class StudentSchool
    {
        public string StudentSchoolKey { get; set; }
        public string StudentKey { get; set; }
        public string SchoolKey { get; set; }
        public string SchoolYear { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentMiddleName { get; set; }
        public string StudentLastName { get; set; }
        public string EnrollmentDateKey { get; set; }
        public string GradeLevel { get; set; }
        public string LimitedEnglishProficiency { get; set; }
        public bool IsHispanic { get; set; }
        public string Sex { get; set; }
        public ICollection<StudentContact> StudentContacts { get; set; }
        public ICollection<StudentSection> StudentSections { get; set; }
    }
}
