namespace myTGA_Common.Dto {
    public class EmployeeReportTaskHoursDto : BaseEntityDto<int> {
        public int TaskId { get; set; }
        public int ReportId { get; set; }
        public int EmployeeId { get; set; }
        public int HoursWorked { get; set; }
        public EmployeeDto Employee { get; set; }
        public TaskDto Task { get; set; }
    }
}
