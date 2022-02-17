using System.Collections.Generic;
using System.ComponentModel;

namespace myTGA_test_project.Models {
    public class ReportHourControlsViewModel {
        public int ReportId { get; set; }
        [DisplayName("Task")]
        public int TaskId { get; set; }
        [DisplayName("Employee")]
        public int EmployeeId { get; set; }
        public int Hours { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
        public List<TaskViewModel> Tasks { get; set; }
    }
}
