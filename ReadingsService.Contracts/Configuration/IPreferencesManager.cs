using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Configuration
{
    public interface IPreferencesManager
    {
        string GetDBUserName();

        string GetDBPassword();

        string GetDBPort();

        string GetDBUrl();

        string GetLogsPath();

    }
}
