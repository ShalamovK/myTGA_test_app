using System.Collections.Generic;

namespace myTGA_Common.Dto {
    public class EmployeeDto : BaseEntityDto<int> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmployeeReportTaskHoursDto> EmployeeTasks { get; set; }
    }
}
