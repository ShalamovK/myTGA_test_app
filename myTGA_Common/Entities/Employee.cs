using System.Collections.Generic;

namespace myTGA_Common.Entities {
    public class Employee : BaseEntity<int> {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // NAVIGATION
        public virtual ICollection<EmployeeReportTaskHours> EmployeeTasks { get; set; }
    }
}
