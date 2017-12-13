using ReadingsService.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.DAOs
{
    interface IDAOProveedores
    {
        bool ValidateProveedor(string username, string password);
    }
}
