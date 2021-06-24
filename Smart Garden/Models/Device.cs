using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.Models
{
    public class Device
    {
        public int Id { get; set; }
        public int DeviceType { get; set; }
        public string IpAddress { get; set; }
        public bool IsActive { get; set; }

        public CultivationPlan CultivationPlan { get; set; }

    }
}
