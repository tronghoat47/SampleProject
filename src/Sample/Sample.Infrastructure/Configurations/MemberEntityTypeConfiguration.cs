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
    public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x => x.ProjectId).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.HasOne(x => x.Employee)
                .WithMany(e => e.Members)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Project)
                .WithMany(p => p.Members)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
