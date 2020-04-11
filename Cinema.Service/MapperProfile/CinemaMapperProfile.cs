using AutoMapper;
using Cinema.Logic.DTO;
using Cinema.Service.Schema.Cinema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Service.MapperProfile
{
    public class CinemaMapperProfile:Profile
    {
        public CinemaMapperProfile()
        {
            CreateMap<CinemaInput, CinemaDTO>();
        }
    }
}
