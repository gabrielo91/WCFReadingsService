using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Utils
{
    public class ProcessIdGenerator
    {
        public static string GenerarConsecutivo() {
            return Guid.NewGuid().ToString();
        }  
    }
}
