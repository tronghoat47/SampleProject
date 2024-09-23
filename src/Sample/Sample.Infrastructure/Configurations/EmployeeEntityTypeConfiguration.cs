using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(10);
            builder.HasIndex(e => e.Code).IsUnique(true);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(e => e.Email).IsUnique(true);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.HasIndex(e => e.PhoneNumber).IsUnique(true);
            builder.Property(e => e.Location).IsRequired();

            builder.HasMany(e => e.Members).WithOne(m => m.Employee).HasForeignKey(m => m.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Tasks).WithOne(t => t.Employee).HasForeignKey(t => t.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.SubTasks).WithOne(st => st.Employee).HasForeignKey(st => st.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
