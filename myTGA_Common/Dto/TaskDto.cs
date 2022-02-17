using System.Collections.Generic;

namespace myTGA_Common.Dto {
    public class TaskDto : BaseEntityDto<int> {
        public string Name { get; set; }
        public List<EmployeeReportTaskHoursDto> EmployeeTasks { get; set; }
    }
}
