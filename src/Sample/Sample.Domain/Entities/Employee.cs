using Sample.Domain.Enums;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Location Location { get; set; }
        public ICollection<Member>? Members { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<SubTask>? SubTasks { get; set; }
    }
}
