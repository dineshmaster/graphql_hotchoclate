using Cinema.Logic.Core.Abstract;
using Cinema.Logic.Core.Concret;
using Cinema.Logic.DTO;
using Cinema.Service.Schema.Cinema;
using Cinema.Service.Test.Infrastructure;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Snapshooter.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cinema.Service.Test
{
    public class CinemaQueryTest
    {
        [Fact]
        public async Task GetCinema_With_Results()
        {
            //arrange
            
            Mock<ICinemaLogic> cinemaLogicMock = new Mock<ICinemaLogic>();
            cinemaLogicMock.Setup(p => p.GetCinemas()).Returns(_GetCinemaList());
            Mock<IServiceProvider> serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(p => p.GetService(typeof(ICinemaLogic))).Returns(cinemaLogicMock.Object);

            IQueryExecutor queryExecutor = QueryExecutorFactory.Create<CinemaQuery>();
            IReadOnlyQueryRequest queryRequest = QueryRequestBuilder.New()
                .SetQuery(@"query GetAllCinemas{
                          cinemas{
                            edges{
                              cursor
                            }
                            nodes{
                              title
                              description
                              iD
                              duration
                            }
                          }
                        }")
                .AddProperty("Key", "value")
                .SetServices(serviceProvider.Object)
                .Create();

            //act
            IExecutionResult result = await queryExecutor.ExecuteAsync(queryRequest);

            //assert
            result.MatchSnapshot();
        }
        private IQueryable<CinemaDTO> _GetCinemaList()
        {
            List<CinemaDTO> cinemas = new List<CinemaDTO>
            {
                new CinemaDTO
                {
                    Description = "Description 1",
                    Duration = 2.50M,
                    ID = 1,
                    Title = "Title1"
                },
                 new CinemaDTO
                {
                    Description = "Description 2",
                    Duration = 3M,
                    ID = 2,
                    Title = "Title2"
                }
            };

            return cinemas.AsQueryable();
        }
    }
}
