using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingsService.Contracts.Models;

namespace ReadingsService.Contracts.DAOs
{
    public class DAOProcessRegistry : IDAOProcessRegistry
    {
        public int InsertProcessRegistry(ProcessRegistry processRegistry)
        {
            throw new NotImplementedException();
        }

        public int InsertProcessRegistryArray(List<ProcessRegistry> processRegistry)
        {
            throw new NotImplementedException();
        }

        public List<ProcessRegistry> retrieveProcessListRegistryByGroupId(string generalProcessId)
        {
            throw new NotImplementedException();
        }

        public ProcessRegistry retrieveProcessRegistryById(string processId)
        {
            throw new NotImplementedException();
        }
    }
}
