using Cinema.Service.Query;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Json;
using Snapshooter.Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cinema.Service.Test
{
    public class HelloQueryTest
    {
        [Fact]
        public async Task HelloQuery_Test() 
        {
            //arrange
            IQueryExecutor executor = SchemaBuilder.New()
                .AddQueryType(p => p.Name("Query"))
                .AddType<HelloQuery>()
                .Create()
                    .MakeExecutable();
            IReadOnlyQueryRequest request = QueryRequestBuilder.New()
                .SetQuery("{hello}")
                .AddProperty("key", "value")
                .Create();
            //act
            IExecutionResult result = await executor.ExecuteAsync(request);

            //assert
            result.MatchSnapshot();
        }
        


    }
}
