using Cinema.Service.Schema.Cinema;
using HotChocolate.Types;

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
