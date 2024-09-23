using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Models
{
    public class GeneralBoolResponse
    {
        public bool success { get; set; } = true;
        public string message { get; set; } = string.Empty;

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
