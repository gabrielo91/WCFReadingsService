using ReadingsService.Contracts.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Logging
{
    public class Logger
    {
        public static readonly string CONFIGURATION_FILE_PATH = @"D:\DesarrolloReadingsService\Recursos\config.json";

        public static void Log(Exception ex) {
            

            var line = Environment.NewLine + Environment.NewLine;

            var ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            var Errormsg = ex.GetType().Name.ToString();
            var extype = ex.GetType().ToString();
            var FullErrorMessage = ex.Message.ToString();
            var ErrorLocation = ex.StackTrace;
                        
            try
            {
                IPreferencesManager preferencesManager = new PreferencesManager(CONFIGURATION_FILE_PATH);
                var logsPath = preferencesManager.GetLogsPath();
                var exists = Directory.Exists(logsPath);
                if (!exists)
                {
                    Directory.CreateDirectory(logsPath);

                }
                logsPath = logsPath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
                if (!File.Exists(logsPath))
                {                    
                    File.Create(logsPath).Dispose();

                }
                using (StreamWriter sw = File.AppendText(logsPath))
                {
                    var error = "Log Written Date:" + " " + DateTime.Now.ToString()
                        + line + "Error Line No :" + " "
                        + ErrorlineNo + line + "Error Message:" + " "
                        + Errormsg + line + "Exception Type:" + " "
                        + extype + line + "Error Message :" + " "
                        + FullErrorMessage + line + "Location :" + " "
                        + ErrorLocation + line;
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Estamos en 2");
                Console.ReadLine();
                e.ToString();
            }

        }
    }
}
