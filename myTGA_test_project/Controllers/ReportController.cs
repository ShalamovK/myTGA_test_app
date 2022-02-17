using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myTGA_Common;
using myTGA_Common.Contracts.Services;
using myTGA_Common.Dto;
using myTGA_Common.Extensions;
using myTGA_test_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myTGA_test_project.Controllers {
    public class ReportController : BaseController {
        public ReportController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper) {
        }

        public IActionResult Index() {
            List<EmployeeReportDto> reports = _serviceProvider.GetTypedService<IReportService>().GetAll();
            List<EmployeeReportViewModel> viewModel = _mapper.Map<List<EmployeeReportViewModel>>(reports);

            return View(viewModel);
        }

        public IActionResult ReportDetails(int id) {
            EmployeeReportDto reportDto = _serviceProvider.GetTypedService<IReportService>().GetReportDetails(id);
            EmployeeReportViewModel viewModel = _mapper.Map<EmployeeReportViewModel>(reportDto);

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult RepairReport(int id) {
            AppResponse response = _serviceProvider.GetTypedService<IReportService>().RepairReport(id);

            return Json(response);
        }

        [HttpGet]
        public PartialViewResult ReportTable(int id) {
            EmployeeReportDto reportDto = _serviceProvider.GetTypedService<IReportService>().GetReportDetails(id);
            EmployeeReportTableViewModel viewModel = _mapper.Map<EmployeeReportTableViewModel>(reportDto.TaskHours);

            return PartialView("Partials/ReportTable", viewModel);
        }

        [HttpGet]
        public PartialViewResult ReportHourControls(int id) {
            ReportHourControlsViewModel viewModel = new ReportHourControlsViewModel();

            List<EmployeeDto> employees = _serviceProvider.GetTypedService<IEmployeeService>().GetAll();
            List<TaskDto> tasks = _serviceProvider.GetTypedService<ITaskService>().GetAll();

            viewModel.Employees = _mapper.Map<List<EmployeeViewModel>>(employees);
            viewModel.Tasks = _mapper.Map<List<TaskViewModel>>(tasks);
            viewModel.ReportId = id;

            return PartialView("Partials/AddHoursControls", viewModel);
        }

        [HttpPost]
        public JsonResult SetHours(int hoursId, int hours) {
            AppResponse response = _serviceProvider.GetTypedService<IReportService>().SetHours(hoursId, hours);

            return Json(response); 
        }

        [HttpPost]
        public JsonResult AddHours(ReportHourControlsViewModel model) {
            AppResponse response = _serviceProvider.GetTypedService<IReportService>().AddHours(model.ReportId, model.TaskId, model.EmployeeId, model.Hours);

            return Json(response);
        }
    }
}
