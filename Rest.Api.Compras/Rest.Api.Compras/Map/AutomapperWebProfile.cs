using Rest.Api.Compras.Common.Web.Dto;
using Rest.Api.Domain1.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Api.Compras.Map
{
    public class AutomaperWebProfile : Profile
    {

        public AutomaperWebProfile()
        {

            CreateMap<ArticuloDto, articulos>().ReverseMap();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }
    }
}