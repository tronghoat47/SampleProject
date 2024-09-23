using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sample.Domain.Entities;
using Sample.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.DataAccess
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Domain.Entities.Task> Tasks { get; set; }
        public virtual DbSet<SubTask> SubTasks { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("SampleDB");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ProjectEntityTypeConfiguration().Configure(modelBuilder.Entity<Project>());
            new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employee>());
            new MemberEntityTypeConfiguration().Configure(modelBuilder.Entity<Member>());
            new TaskEntityTypeConfiguration().Configure(modelBuilder.Entity<Domain.Entities.Task>());
            new SubTaskEntityTypeConfiguration().Configure(modelBuilder.Entity<SubTask>());
            new SprintEntityTypeConfiguration().Configure(modelBuilder.Entity<Sprint>());
        }
    }
}
