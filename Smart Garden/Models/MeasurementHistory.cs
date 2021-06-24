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
        public float Value { get; set; }
    }
}