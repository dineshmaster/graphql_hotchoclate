using AutoMapper;
using Cinema.Logic.DTO;
using Cinema.Logic.Mapper.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Logic.Mapper.Concret
{
    public class CinemaMapper:ICustomMapper
    {
        private readonly IMapper mapper;
        public CinemaMapper()
        {
            var config = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<Cinema.Model.Entity.Cinema, CinemaDTO>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }
        public IMapper Mapper => mapper;
    }
}
