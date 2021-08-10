using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.Models.Dtos
{
    public class DeviceSettingsDto
    {
        public int LightingThreshold { get; set; }
        public int WateringThreshold { get; set; }
        public int WateringDuration { get; set; }
        public int SoilMoisMax { get; set; }
        public bool BuzzerMuted { get; set; }
    }
}
