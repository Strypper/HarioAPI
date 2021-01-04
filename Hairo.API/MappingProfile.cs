using AutoMapper;
using Hairo.Entities;
using Hairo.Entities.Location;
using Hario.DataObject;
using Hario.DataObject.LocationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairo.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreDTO>().ReverseMap().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<Service, ServiceDTO>().ReverseMap().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<ChildService, ChildServiceDTO>().ReverseMap().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<City, CityDTO>().ReverseMap().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<District, DistrictDTO>().ReverseMap().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<LocationAddress, LocationAddressDTO>().ReverseMap().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<LocationPhoto, LocationPhotoDTO>().ReverseMap().ForMember(d => d.Id, o => o.Ignore());
        }
    }
}
