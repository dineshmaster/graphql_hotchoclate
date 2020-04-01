using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Service.SchemaType
{
    public class HelloType:ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field("hello").Resolver(() => "Hello World");
        }
    }
}
