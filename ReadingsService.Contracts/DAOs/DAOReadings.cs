﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingsService.Contracts.Models;

namespace ReadingsService.Contracts.DAOs
{
    public class DAOReadings : IDAOReadings
    {
        public bool CheckIfExist(Readings reading)
        {
            throw new NotImplementedException();
        }

        public string Save(List<Readings> readingsList)
        {
            throw new NotImplementedException();
        }

        public string SaveIfNotExists(List<Readings> readingsList)
        {
            throw new NotImplementedException();
        }
    }
}
