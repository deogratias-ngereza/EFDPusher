using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDPusher.App.Models
{
    public class ConfigurationModel
    {
        public string source_path {get;set;}
        public string destination_ip { get; set; }

        public ConfigurationModel() {
            this.source_path = @"c:/dpool/in";
            this.destination_ip = @"http://localhost:6677/efd_raw";
        }

    }
}
