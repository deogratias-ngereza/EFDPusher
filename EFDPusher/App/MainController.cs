using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFDPusher.App.Models;
using System.IO;

namespace EFDPusher.App
{
    public class MainController
    {
        public string get_my_path()
        {
            var executing_path = AppDomain.CurrentDomain.BaseDirectory;
            string targetDir = string.Format(executing_path + @"\");
            return targetDir;
        }
        /*CURRENT USER OBJECT*/
        public ConfigurationModel getConfigurations()
        {
            try
            {
                //open the file
                using (StreamReader r = new StreamReader(this.get_my_path() + @"config.json"))
                {
                    string json = r.ReadToEnd();
                    ConfigurationModel configObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigurationModel>(json);
                    return configObject;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ ERROR ] " + ex.Message);
                return new ConfigurationModel();
            }
        }//
    }
}
