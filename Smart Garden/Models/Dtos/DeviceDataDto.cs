using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SmartGarden.Models
{
    public class DeviceDataDto
    {
        public float tempValue { get; set; }
        public int soilMoisValue { get; set; }
        public int humidValue { get; set; }
        public bool waterValue { get; set; }
        public int lightValue { get; set; }
        public int lightingThreshold { get; set; }
        public int wateringThreshold { get; set; }
        public int wateringDuration { get; set; }
        public int soilMoisMax { get; set; }
        public bool buzzerMuted { get; set; }
    }
}
