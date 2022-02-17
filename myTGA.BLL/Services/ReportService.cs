using AutoMapper;
using myTGA_Common;
using myTGA_Common.Contracts;
using myTGA_Common.Contracts.Services;
using myTGA_Common.Dto;
using myTGA_Common.Entities;
using myTGA_Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myTGA.BLL.Services {
    public class ReportService : BaseService, IReportService {
        public ReportService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        public AppResponse AddHours(int reportId, int taskId, int employeeId, int hours) {
            try {
                EmployeeReportTaskHours taskHours = new EmployeeReportTaskHours {
                    ReportId = reportId,
                    EmployeeId = employeeId,
                    HoursWorked = hours,
                    TaskId = taskId
                };

                _unitOfWork.GetRepository<EmployeeReportTaskHours>().Add(taskHours);
                _unitOfWork.SaveChanges();

                return new AppResponse(true, "Hours added");
            } catch (Exception ex) {
                return new AppResponse(false, "An error occured");
            }
        }

        public List<EmployeeReportDto> GetAll() {
            List<EmployeeReport> reports = _unitOfWork.GetRepository<EmployeeReport>().GetAll().ToList();

            return _mapper.Map<List<EmployeeReportDto>>(reports);
        }

        public EmployeeReportDto GetReportDetails(int id) {
            EmployeeReport report = _unitOfWork.GetRepository<EmployeeReport>().GetAll().FirstOrDefault(x => x.Id == id);

            return _mapper.Map<EmployeeReportDto>(report);
        }

        public AppResponse RepairReport(int id) {
            EmployeeReport report = _unitOfWork.GetRepository<EmployeeReport>().GetAll().FirstOrDefault(x => x.Id == id);

            if (report == null) {
                return new AppResponse(false, "Report not found");
            }

            if (report.TaskHours.IsEmpty()) {
                return new AppResponse(true, "Nothing to repair");
            }

            Dictionary<string, EmployeeReportTaskHours> taskHours = new Dictionary<string, EmployeeReportTaskHours>();
            List<EmployeeReportTaskHours> tasksToRemove = new List<EmployeeReportTaskHours>();

            foreach (EmployeeReportTaskHours reportTaskHours in report.TaskHours) {
                string key = $"{reportTaskHours.EmployeeId}{reportTaskHours.TaskId}";

                if (taskHours.ContainsKey(key)) {
                    taskHours[key].HoursWorked += reportTaskHours.HoursWorked;

                    tasksToRemove.Add(reportTaskHours);
                } else {
                    taskHours.Add(key, reportTaskHours);
                }
            }

            if (tasksToRemove.Any()) {
                _unitOfWork.GetRepository<EmployeeReportTaskHours>().Delete(tasksToRemove);
            }

            _unitOfWork.SaveChanges();
            return new AppResponse(true, "Repair complete");
        }

        public AppResponse SetHours(int taskHoursId, int hours) {
            EmployeeReportTaskHours taskHours = _unitOfWork.GetRepository<EmployeeReportTaskHours>().GetAll().FirstOrDefault(x => x.Id == taskHoursId);

            if (taskHours == null) {
                return new AppResponse(false, "Task hours not found");
            }

            taskHours.HoursWorked = hours;
            _unitOfWork.SaveChanges();

            return new AppResponse(true, "Hours saved");
        }
    }
}
