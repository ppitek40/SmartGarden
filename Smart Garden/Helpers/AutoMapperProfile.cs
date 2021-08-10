using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SmartGarden.Models;
using SmartGarden.Models.Dtos;

namespace SmartGarden.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Device, Device>();
            CreateMap<CultivationPlan, CultivationPlan>();
            CreateMap<CultivationPlan, DeviceSettingsDto>()
                .ForMember(dest=>dest.LightingThreshold, 
                    opt=>opt.MapFrom(src=>src.LightningThreshold));
        }
    }
}
