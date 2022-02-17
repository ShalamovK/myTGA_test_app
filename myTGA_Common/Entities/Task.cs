using System.Collections.Generic;

namespace myTGA_Common.Entities {
    public class Task : BaseEntity<int> {
        public string Name { get; set; }

        // NAVIGATION
        public virtual ICollection<EmployeeReportTaskHours> EmployeeTasks { get; set; }
    }
}
