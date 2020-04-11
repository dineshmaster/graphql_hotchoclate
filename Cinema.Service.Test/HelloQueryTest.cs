using Cinema.Service.Schema.Hello;
using Cinema.Service.Test.Infrastructure;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
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
            IQueryExecutor queryExecutor = QueryExecutorFactory.Create<HelloQuery>();
            IReadOnlyQueryRequest request = QueryRequestBuilder.New()
                .SetQuery("{hello}")
                .AddProperty("key", "value")
                .Create();
            //act
            IExecutionResult result = await queryExecutor.ExecuteAsync(request);

            //assert
            result.MatchSnapshot();
        }
        


    }
}
