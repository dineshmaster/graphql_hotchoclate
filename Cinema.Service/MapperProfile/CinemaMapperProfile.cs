﻿using AutoMapper;
using Cinema.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Service.MapperProfile
{
    public class CinemaMapperProfile:Profile
    {
        public CinemaMapperProfile()
        {
            CreateMap<Cinema.Model.Entity.Cinema, CinemaDTO>();
        }
    }
}