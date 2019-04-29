using Microsoft.EntityFrameworkCore;
using timesheet.model;

namespace timesheet.data
{
    public class TimesheetDb : DbContext
    {
        public TimesheetDb(DbContextOptions<TimesheetDb> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkLog>()
                        .HasOne(pt => pt.Employee)
                        .WithMany(p => p.WorkLogs)
                        .IsRequired(true)
                        .HasForeignKey(pt => pt.EmployeeId);

            modelBuilder.Entity<WorkLog>()
                        .HasOne(pt => pt.Task)
                        .WithMany(p => p.WorkLogs)
                        .HasForeignKey(pt => pt.TaskId);

            modelBuilder.Entity<Employee>().Ignore(x => x.WorkLogs);
            modelBuilder.Entity<Task>().Ignore(x => x.WorkLogs);

            base.OnModelCreating(modelBuilder);
        }
    }
}
