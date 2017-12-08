using ReadingsService.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.DAOs
{
    interface IDAOProcessRegistry
    {
        int InsertProcessRegistry(ProcessRegistry processRegistry);

        int InsertProcessRegistryArray(List<ProcessRegistry> processRegistry);

        ProcessRegistry retrieveProcessRegistryById(string processId);

        List<ProcessRegistry> retrieveProcessListRegistryByGroupId(string generalProcessId);
    }
}
