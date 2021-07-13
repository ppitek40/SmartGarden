using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using SmartGarden.Models.Enums;

namespace SmartGarden.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(EDeviceType))]
        public EDeviceType DeviceType { get; set; }
        public string IpAddress { get; set; }
        public bool IsActive { get; set; }
        public int? CultivationPlanId { get; set; }
        public CultivationPlan CultivationPlan { get; set; }

    }
}
