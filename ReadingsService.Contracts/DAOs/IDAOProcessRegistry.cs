using ReadingsService.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.DAOs
{
    public interface IDAOProcessRegistry
    {
        
        bool InsertProcessRegistry(ProcessRegistry processRegistry);

        bool UpdateProcessRegistry(ProcessRegistry processRegistry);

        ProcessRegistry retrieveProcessRegistryById(string processId);

        List<ProcessRegistry> retrieveProcessListRegistryByGroupId(string generalProcessId);
    }
}
