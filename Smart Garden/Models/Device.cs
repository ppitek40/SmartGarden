using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;


namespace SmartGarden.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceMdns { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Version { get; set; }
        public int? CultivationPlanId { get; set; }
        public CultivationPlan CultivationPlan { get; set; }

    }
}
