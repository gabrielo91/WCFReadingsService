﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Models
{
    class DatabaseSimpleResult
    {
        public bool OperationSucced { get; set; }
        public string TechnicalMessage { get; set; }
    }
}
