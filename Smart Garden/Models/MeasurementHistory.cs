using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.Models
{
    public class MeasurementHistory
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public float tempValue { get; set; }
        public int soilMoisValue { get; set; }
        public int humidValue { get; set; }
        public bool waterValue { get; set; }
        public int lightValue { get; set; }
    }
}