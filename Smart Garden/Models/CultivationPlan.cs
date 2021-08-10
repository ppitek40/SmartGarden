﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.Models
{
    public class CultivationPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LightningThreshold { get; set; }
        public int WateringThreshold { get; set; }
        public int WateringDuration { get; set; }
        public int SoilMoisMax { get; set; }
        public bool BuzzerMuted { get; set; }
    }
}
