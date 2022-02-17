using System;
using System.Collections.Generic;

namespace myTGA_Common.Dto {
    public class EmployeeReportDto : BaseEntityDto<int> {
        public string Name { get; set; }
        public DateTime ReportDate { get; set; }

        public List<EmployeeReportTaskHoursDto> TaskHours { get; set; }
    }
}
