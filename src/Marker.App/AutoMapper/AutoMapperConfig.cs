using AutoMapper;
using Marker.App.ViewModels;
using Marker.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marker.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig ()
        {
            CreateMap<Sala, SalaViewModel>().ReverseMap();
            CreateMap<Reuniao, ReuniaoViewModel>().ReverseMap();

        }
    }
}
