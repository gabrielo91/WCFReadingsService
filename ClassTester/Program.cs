using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingsService.Contracts.Controller;
using ReadingsService.Contracts.Configuration;
using ReadingsService.Contracts.Logging;

namespace ClassTester
{
    class Program
    {
        static void Main(string[] args)
        {

            IPreferencesManager preferencesManager = new PreferencesManager(@"D:\DesarrolloReadingsService\Recursos\config.json");

            try
            {
                Console.WriteLine("Empezando");
                int a = 5;
                int b = 0;
                int resultado = a/b;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("estamos en exception");
                Console.ReadLine();
                Logger.Log(e);
            }

        }
    }
}
