using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;
// ReSharper disable VirtualMemberCallInConstructor

namespace EdFi.FIF.GraphQL.Models
{
    public class StudentSchoolType : ObjectGraphType<StudentSchool>
    {
        public StudentSchoolType(ContextServiceLocator contextServiceLocator)
        {
            Field("studentschoolkey", x => x.StudentSchoolKey);
            Field("studentkey", x => x.StudentKey);
            Field("studentfirstname", x => x.StudentFirstName);
            Field("studentmiddlename", x => x.StudentMiddleName);
            Field("studentlastname", x => x.StudentLastName);
            Field("schoolkey", x => x.SchoolKey);
            Field<StringGraphType>("enrollmentdatekey", resolve: context => context.Source.EnrollmentDateKey);
            Field("gradelevel", x => x.GradeLevel);
            Field("limitedenglishproficiency", x => x.LimitedEnglishProficiency);
            Field("ishispanic", x => x.IsHispanic);
            Field("sex", x => x.Sex);
        }
    }
}