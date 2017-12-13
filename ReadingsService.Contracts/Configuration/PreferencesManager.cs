using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ReadingsService.Contracts.Configuration
{
    public class PreferencesManager : IPreferencesManager
    {

        private readonly string dbPassword;
        private readonly string dbPort;
        private readonly string dbUrl;
        private readonly string dbUsername;
        private readonly string losgPath;


        public PreferencesManager(string filePathUrl) {
 
            try
            {
                var streamReader = new StreamReader(filePathUrl);
                var json = streamReader.ReadToEnd();
                var serializer = new JavaScriptSerializer();
                var configuration = serializer.Deserialize<ConfigurationModel>(json);

                dbPassword = configuration.password;
                dbPort = configuration.port;
                dbUrl = configuration.password;
                dbUsername = configuration.url;
                losgPath = configuration.logspath;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+ e);
                throw new IOException();
            }            
                                    
        }

        public string GetLogsPath()
        {
            return this.losgPath;
        }


        public string GetDBPassword()
        {
            return this.dbPassword;
        }

        public string GetDBPort()
        {
            return this.dbPort;
        }

        public string GetDBUrl()
        {
            return this.dbUrl;
        }

        public string GetDBUserName()
        {
            return this.dbUsername;
        }

    }
}
