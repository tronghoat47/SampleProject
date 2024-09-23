using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Models
{
    public class InvalidDataResponse
    {
        public string Message { get; set; } = string.Empty;
        public object? Errors { get; set; } = null;
    }

}
