using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using myTGA_Common.Dto;
using myTGA_Common.Entities;
using myTGA_test_project.Models;
using System.Collections.Generic;
using System.Linq;

namespace myTGA_test_project.App_Start {
    public class AutomapperProfile : Profile {
        public AutomapperProfile() {
            #region [ ENTITY <-> DTO ]

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeReportTaskHours, EmployeeReportTaskHoursDto>();
            CreateMap<EmployeeReport, EmployeeReportDto>();
            CreateMap<Task, TaskDto>();

            #endregion
            #region [ DTO <-> VM ]

            CreateMap<EmployeeDto, EmployeeViewModel>();
            CreateMap<TaskDto, TaskViewModel>();

            CreateMap<List<EmployeeReportTaskHoursDto>, EmployeeReportTableViewModel>()
                .ForMember(trg => trg.Employees, opt => opt.Ignore())
                .ForMember(trg => trg.Lines, opt => opt.Ignore())
                .AfterMap((src, trg) => {
                    trg.Employees = new List<EmployeeViewModel>();
                    trg.Lines = new List<EmployeeReportTableLineViewModel>();

                    // Get employees
                    foreach (EmployeeReportTaskHoursDto hours in src) {
                        if (hours.Employee != null && !trg.Employees.Any(x => x.Id == hours.EmployeeId)) {
                            trg.Employees.Add(new EmployeeViewModel {
                                Id = hours.Employee.Id,
                                FirstName = hours.Employee.FirstName,
                                LastName = hours.Employee.LastName
                            });
                        }
                    }

                    trg.Employees.OrderBy(x => x.NameFormatted);
                    Dictionary<int, int> employeeIndexes = trg.Employees.Select((x, i) => new { x.Id, Index = i }).ToDictionary(x => x.Id, x => x.Index);

                    // Create report lines
                    foreach (EmployeeReportTaskHoursDto hours in src) {
                        EmployeeReportTableLineViewModel lineViewModel = trg.Lines.FirstOrDefault(x => x.Task.Id == hours.TaskId);
                        int employeeIndex = employeeIndexes[hours.EmployeeId];
                        bool createNew = false;

                        if (lineViewModel == null || lineViewModel.EmployeeHours[employeeIndex].Hours != 0) {
                            createNew = true;
                        }

                        if (createNew) {
                            lineViewModel = new EmployeeReportTableLineViewModel {
                                Task = new TaskViewModel {
                                    Id = hours.Task.Id,
                                    Name = hours.Task.Name
                                },
                                EmployeeHours = new EmployeeReportTableLineHoursViewModel[trg.Employees.Count]
                            };

                            for (int i = 0; i < lineViewModel.EmployeeHours.Length; i++) {
                                lineViewModel.EmployeeHours[i] = new EmployeeReportTableLineHoursViewModel();
                            }

                            trg.Lines.Add(lineViewModel);
                        }

                        lineViewModel.EmployeeHours[employeeIndex].Hours = hours.HoursWorked;
                        lineViewModel.EmployeeHours[employeeIndex].EmployeeReportTaskHoursId = hours.Id;
                    };
                });

            CreateMap<EmployeeReportDto, EmployeeReportViewModel>()
                .ForMember(trg => trg.Table, opt => opt.MapFrom(src => src.TaskHours));

            #endregion
        }
    }
}
