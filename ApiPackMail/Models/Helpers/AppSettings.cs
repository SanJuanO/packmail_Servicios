using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackMail.Models.Helpers
{
    public class AppSettings
    {
        public AppSettings()
        {
        }
        public string Connection_dev { get; set; }
        public string Connection_prod { get; set; }
        public string Directory { get; set; }
        public bool debug { get; set; }

    }
}
