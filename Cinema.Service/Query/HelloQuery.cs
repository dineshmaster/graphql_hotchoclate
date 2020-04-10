using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Service.Query
{
    [ExtendObjectType(Name ="Query")]
     public class HelloQuery
    {
        public string hello() => "Hello World1";
    }
}
