using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myTGA_Common.Entities;
using System;
using System.Linq;

namespace myTGA.DAL {
    public class DbSeed {
        public static void SeedData(IServiceProvider serviceProvider) {
            using (var scope = serviceProvider.CreateScope()) {
                var dbContextFactory = scope.ServiceProvider.GetService<IDbContextFactory<myTGADbContext>>();

                using (var db = dbContextFactory.CreateDbContext()) {

                    if (db == null) {
                        throw new NullReferenceException("Db context");
                    }

                    // This will [try to] create database
                    // and apply all necessary migrations
                    db.Database.Migrate();

                    Employee employee1 = _CreateEmployee(db, "John", "Doe");
                    Employee employee2 = _CreateEmployee(db, "Chad", "Mighty");
                    Employee employee3 = _CreateEmployee(db, "Kenny", "McCormick");
                    Employee employee4 = _CreateEmployee(db, "Jimmy", "Hendricks");

                    DateTime now = DateTime.Now;

                    EmployeeReport report1 = _CreateReport(db, "Report 1", now.AddMonths(-1));
                    EmployeeReport report2 = _CreateReport(db, "Report 2", now.AddMonths(-2));
                    EmployeeReport report3 = _CreateReport(db, "Report 3", now.AddMonths(-3));

                    Task task1 = _CreateTask(db, "Clean Floor");
                    Task task2 = _CreateTask(db, "Sipping coffee");
                    Task task3 = _CreateTask(db, "Watching vids");
                    Task task4 = _CreateTask(db, "Smashing buttons");
                    Task task5 = _CreateTask(db, "Doing productive stuff");

                    //int[] employeeIds = new int[] { employee1.Id, employee2.Id, employee3.Id };
                    //int[] taskIds = new int[] { task1.Id, task2.Id, task3.Id, task4.Id, task5.Id };
                    //int[] reportIds = new int[] { report1.Id, report2.Id, report3.Id };


                    //for (int i = 0; i < 100; i++) {
                    //    _CreateEmployeeTask(db, reportIds, employeeIds, taskIds);
                    //    db.SaveChanges();
                    //}
                }
            }
        }

        private static Employee _CreateEmployee(myTGADbContext context, string firstName, string lastName) {
            Employee employee = context.Employees.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (employee == null) {
                employee = new Employee {
                    FirstName = firstName,
                    LastName = lastName
                };

                context.Employees.Add(employee);
                context.SaveChanges();
            }

            return employee;
        }

        private static Task _CreateTask(myTGADbContext context, string name) {
            Task task = context.Tasks.FirstOrDefault(x => x.Name == name);

            if (task == null) {
                task = new Task {
                    Name = name
                };

                context.Tasks.Add(task);
                context.SaveChanges();
            }

            return task;
        }

        private static EmployeeReport _CreateReport(myTGADbContext context, string name, DateTime date) {
            EmployeeReport report = context.EmployeeReports.FirstOrDefault(x => x.Name == name);

            if (report == null) {
                report = new EmployeeReport {
                    Name = name,
                    ReportDate = date
                };

                context.EmployeeReports.Add(report);
                context.SaveChanges();
            }

            return report;
        }

        private static EmployeeReportTaskHours _CreateEmployeeTask(myTGADbContext context, int[] reportIds, int[] employeeIds, int[] taskIds) {
            Random random = new Random();
            int eIndex = random.Next(0, employeeIds.Length);
            int tIndex = random.Next(0, taskIds.Length);
            int rIndex = random.Next(0, reportIds.Length);

            int employeeId = employeeIds[eIndex];
            int taskId = taskIds[tIndex];
            int reportId = reportIds[rIndex];
            int hours = random.Next(0, 10);

            EmployeeReportTaskHours task = new EmployeeReportTaskHours {
                HoursWorked = hours,
                ReportId = reportId,
                EmployeeId = employeeId,
                TaskId = taskId
            };

            context.EmployeeReportTaskHours.Add(task);

            return task;
        }
    }
}
