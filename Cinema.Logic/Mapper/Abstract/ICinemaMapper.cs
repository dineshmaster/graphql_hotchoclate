using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Logic.Mapper.Abstract
{
    public interface ICinemaMapper
    {
        IMapper Mapper { get; }
    }
}
