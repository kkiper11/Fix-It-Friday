using System;

namespace EdFi.FIF.Core.Models
{
    public class StaffSectionAssociation
    {
        public int StaffKey { get; set; }
        public string SectionKey { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Staff Staff { get; set; }

        public Section Section { get; set; }
    }
}
