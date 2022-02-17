using Microsoft.EntityFrameworkCore;
using myTGA_Common.Entities;

namespace myTGA.DAL {
    public class myTGADbContext : DbContext {
        public myTGADbContext(DbContextOptions<myTGADbContext> options) 
            : base(options) {
        }

        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Task> Tasks { get; set; } 
        public DbSet<EmployeeReport> EmployeeReports { get; set; }
        public DbSet<EmployeeReportTaskHours> EmployeeReportTaskHours { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Fluent API here

            modelBuilder.Entity<EmployeeReportTaskHours>()
                .HasOne(x => x.EmployeeReport)
                .WithMany(x => x.TaskHours)
                .HasForeignKey(x => x.ReportId);
        }
    }
}
