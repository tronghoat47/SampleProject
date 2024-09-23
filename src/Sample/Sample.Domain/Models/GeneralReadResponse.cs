using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Models
{
    public class GeneralReadResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; } = null;
    }

    public class PaginationResponse : GeneralReadResponse
    {
        public Meta? Meta { get; set; }
    }

    public class Meta
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
    }

}
