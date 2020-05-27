using System;
using System.Collections.Generic;

namespace EdFi.FIF.Core.Models
{
    public class Section
    {
        public string SectionKey { get; set; }
        public string SchoolKey { get; set; }
        public string LocalCourseCode { get; set; }
        public string SessionName { get; set; }
        public string SectionIdentifier { get; set; }
        public Int16 SchoolYear { get; set; }
    }
}
