using Sample.Domain.Enums;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Entities
{
    public class SubTask : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double LoggedHourTime { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; } = null!;
        public Enums.TaskStatus Status { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
