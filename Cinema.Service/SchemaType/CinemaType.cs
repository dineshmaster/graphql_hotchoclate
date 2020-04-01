using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Model.Entity;
using Cinema.Service.Query;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Cinema.Service.SchemaType
{
    public class CinemaType:ObjectType<CinemaQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<CinemaQuery> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(p => p.GetCinemas(default));
        }
    }
}
