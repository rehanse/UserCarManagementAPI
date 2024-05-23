using AutoMapper;
using UserCarManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCarManagementAPI.UserInfra.Mapping
{
    public class ModelProfiler:Profile
    {
        public ModelProfiler()
        {
            CreateMap<CarDTO, Car>()
                .ForMember(dest => dest.model, opt => opt.MapFrom(src => src.carModel));
        }
    }
}
