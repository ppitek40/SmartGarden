using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SmartGarden.Models.Dtos
{
    public class HealthcheckDto
    {
        public string device { get; set; }
        public string version { get; set; }
        public string mdnsDomain { get; set; }
        public string localIP { get; set; }
    }
}
