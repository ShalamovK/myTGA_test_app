using System;
using System.Collections.Generic;
using System.Text;

namespace myTGA_Common.Entities {
    public class EmployeeReport : BaseEntity<int> {
        public string Name { get; set; }
        public DateTime ReportDate { get; set; }

        // Navigation
        public virtual ICollection<EmployeeReportTaskHours> TaskHours { get; set; }
    }
}
