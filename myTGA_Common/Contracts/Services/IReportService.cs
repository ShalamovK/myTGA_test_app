using myTGA_Common.Dto;
using System.Collections.Generic;

namespace myTGA_Common.Contracts.Services {
    public interface IReportService : IBaseService {
        public EmployeeReportDto GetReportDetails(int id);
        public AppResponse SetHours(int taskHoursId, int hours);
        public AppResponse AddHours(int reportId, int taskId, int employeeId, int hours);
        public AppResponse RepairReport(int id);
        public List<EmployeeReportDto> GetAll();
    }
}
