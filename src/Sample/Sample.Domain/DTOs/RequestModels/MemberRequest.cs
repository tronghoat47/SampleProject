using Sample.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.DTOs.RequestModels
{
    public class MemberCreateRequest
    {
        public string EmployeeCode { get; set; } = string.Empty;
        public string ProjectCode { get; set; } = string.Empty;
        public Role Role { get; set; }
    }

    public class MemberUpdateRequest
    {
        public Role Role { get; set; }
    }
}
