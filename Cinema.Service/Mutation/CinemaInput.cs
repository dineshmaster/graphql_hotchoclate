using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Service.Mutation
{
    public class CinemaInput
    {
        public CinemaInput(string title,string description)
        {
            Title = title;
            Description = description;
        }
        public string Title { get;  }
        public string Description { get; set; }
    }
}
