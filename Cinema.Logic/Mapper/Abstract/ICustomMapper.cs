using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Logic.Mapper.Abstract
{
    public interface ICustomMapper
    {
        IMapper Mapper { get; }
    }
}
