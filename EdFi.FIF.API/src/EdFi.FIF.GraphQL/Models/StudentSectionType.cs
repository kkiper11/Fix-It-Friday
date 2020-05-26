using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;
// ReSharper disable VirtualMemberCallInConstructor

namespace EdFi.FIF.GraphQL.Models
{
    public class StudentSectionType : ObjectGraphType<StudentSection>
    {
        public StudentSectionType(ContextServiceLocator contextServiceLocator)
        {
            Field("studentsectionkey", x => x.StudentSectionKey);
            Field("studentschoolkey", x => x.StudentSchoolKey);
            Field("studentkey", x => x.StudentKey);
            Field("sectionkey", x => x.SectionKey);
            Field("localcoursecode", x => x.LocalCourseCode);
            Field("subject", x => x.Subject);
            Field("coursetitle", x => x.CourseTitle);
            Field("teachername", x => x.TeacherName);
            Field("studentsectionstartdatekey", x => x.StudentSectionStartDateKey);
            Field("studentsectionenddatekey", x => x.StudentSectionEndDateKey);
            Field("schoolkey", x => x.SchoolKey);
            Field("schoolyear", x => x.SchoolYear);
        }
    }
}