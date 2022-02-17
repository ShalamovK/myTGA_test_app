using System;
using System.Collections.Generic;

namespace myTGA_test_project.Models {
    public class EmployeeReportViewModel : BaseEntityViewModel<int> {
        public string Name { get; set; }
        public DateTime ReportDate { get; set; }

        public EmployeeReportTableViewModel Table { get; set; }

        public string DateFormatted => this.ReportDate.ToShortDateString();
    }

    public class EmployeeReportTableViewModel { 
        public List<EmployeeViewModel> Employees { get; set; }
        public List<EmployeeReportTableLineViewModel> Lines { get; set; }
    }

    public class EmployeeReportTableLineViewModel {
        public TaskViewModel Task { get; set; }
        public EmployeeReportTableLineHoursViewModel[] EmployeeHours { get; set; }
    }

    public class EmployeeReportTableLineHoursViewModel {
        public int EmployeeReportTaskHoursId { get; set; }
        public int Hours { get; set; }
    }
}
