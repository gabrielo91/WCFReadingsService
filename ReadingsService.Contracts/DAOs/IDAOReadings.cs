using ReadingsService.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.DAOs
{
    public interface IDAOReadings
    {
        bool CheckIfExist(Readings reading);
        string Save(List<Readings> readingsList);
        string SaveIfNotExists(List<Readings> readingsList);
    }
}
