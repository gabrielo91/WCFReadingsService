using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Configuration
{
    public class ConfigurationModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string port { get; set; }
        public string url { get; set; }
        public string logspath { get; set; }
    }
}
