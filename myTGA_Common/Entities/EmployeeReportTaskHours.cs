namespace myTGA_Common.Entities {
    public class EmployeeReportTaskHours : BaseEntity<int> {
        public int TaskId { get; set; }
        public int ReportId { get; set; }
        public int EmployeeId { get; set; }
        public int HoursWorked { get; set; }

        // NAVIGATION
        public virtual EmployeeReport EmployeeReport { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
