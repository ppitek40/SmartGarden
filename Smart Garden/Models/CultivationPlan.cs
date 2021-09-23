using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.Models
{
    public class CultivationPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Required]
        [Range(1, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name="Lightning Threshold")]
        public int LightningThreshold { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Watering Threshold")]
        public int WateringThreshold { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Watering Duration")]
        public int WateringDuration { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Maximum Soil Moisture")]
        public int SoilMoisMax { get; set; }

        [Display(Name = "Mute Buzzer")]
        public bool BuzzerMuted { get; set; }
    }
}
