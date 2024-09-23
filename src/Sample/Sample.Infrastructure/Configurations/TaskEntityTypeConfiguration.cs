using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain.Entities;
using Sample.Domain.Enums;
using Sample.Domain.Models;
using System;

namespace Sample.Infrastructure.Configurations
{
    public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.LoggedHourTime).IsRequired();
            builder.Property(x => x.SprintId).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.EmployeeId).IsRequired();

            builder.HasOne(x => x.Sprint).WithMany(x => x!.Tasks).HasForeignKey(x => x.SprintId);
            builder.HasOne(x => x.Employee).WithMany(x => x!.Tasks).HasForeignKey(x => x.EmployeeId);
            builder.HasMany(x => x.SubTasks).WithOne(x => x.Task).HasForeignKey(x => x.TaskId);
        }
    }
}
