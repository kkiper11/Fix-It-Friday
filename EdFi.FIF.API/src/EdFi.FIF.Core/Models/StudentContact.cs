namespace EdFi.FIF.Core.Models
{
    public class StudentContact
    {
        public string StudentSchoolKey { get; set; }

        public string ContactPersonKey { get; set; }

        public StudentSchool StudentSchool { get; set; }
        public ContactPerson ContactPerson { get; set; }
    }
}
