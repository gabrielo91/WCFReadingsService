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
        bool Save(List<Readings> readingsList);
        bool SaveIfNotExists(List<Readings> readingsList);
    }
}
