using AutoMapper;
using GEM.PowerPlant.Api.Dtos;
using GEM.PowerPlant.Api.Models;

namespace GEM.PowerPlant.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Multitude, ResponseDetail>();
        }
    }
}