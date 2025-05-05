using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uttt.Rest.SqlApi.Domain;
using Uttt.Rest.SqlApi.Dto;

namespace Uttt.Rest.SqlApi.Mapper
{
    public class MangerProfile : Profile
    {
        public MangerProfile()
        {
            CreateMap<Telefonos,TelefonosDto>().ReverseMap();
            CreateMap<Direcciones, DireccionesDto>().ReverseMap();
            CreateMap<Personas, PersonasDto>().ReverseMap()
                .ForMember(d => d.Telefonos, o => o.MapFrom(a=> a.Telefonos))
                .ForMember(d => d.Direcciones, o=> o.MapFrom(l=>l.Direcciones) );
        }
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<MangerProfile>();
            });
        }
    }
}