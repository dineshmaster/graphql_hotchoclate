using Cinema.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Logic.Core.Abstract
{
    public interface ICinemaLogic
    {
        IQueryable<CinemaDTO> GetCinemas();
    }
}
