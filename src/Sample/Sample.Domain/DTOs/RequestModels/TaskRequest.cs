using Sample.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.DTOs.RequestModels
{
    public class TaskRequestCreate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SprintId { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
    }

    public class TaskRequestUpdate
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double LoggedHourTime { get; set; }
        public int SprintId { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
    }
}
