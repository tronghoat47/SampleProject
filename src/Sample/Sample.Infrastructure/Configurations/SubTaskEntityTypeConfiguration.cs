using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using Sample.Domain.Enums;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Configurations
{
    public class SubTaskEntityTypeConfiguration : IEntityTypeConfiguration<SubTask>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SubTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.LoggedHourTime).IsRequired();
            builder.Property(x => x.TaskId).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.EmployeeId).IsRequired();

            builder.HasOne(x => x.Task)
                .WithMany(x => x!.SubTasks)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x!.SubTasks)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
