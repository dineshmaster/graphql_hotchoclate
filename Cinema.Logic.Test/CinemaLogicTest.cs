using Cinema.Logic.Core.Abstract;
using Cinema.Logic.Core.Concret;
using Cinema.Logic.DTO;
using Cinema.Logic.Mapper.Concret;
using Cinema.Model.RepositoryCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Cinema.Logic.Test
{
    public class CinemaLogicTest
    {
        [Fact]
        public void GetCinemas_With_Result()
        {
            //arrange
            Mock<CinemaMapper> cinemaMapper = new Mock<CinemaMapper>();
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            CinemaLogic cinemaLogic = new CinemaLogic(unitOfWork.Object, cinemaMapper.Object);
            unitOfWork.Setup(p => p.cinemaRepository.Get(null,null,"")).Returns(_GetCinemas().AsEnumerable());
            //act
            var cinemas = cinemaLogic.GetCinemas();

            //assert
            Assert.NotNull(cinemas);
            Assert.Equal(2,cinemas.Count());
        }
        [Fact]
        public void GetCinemas_With_Empty_Result()
        {
            //arrange
            Mock<CinemaMapper> cinemaMapper = new Mock<CinemaMapper>();
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            CinemaLogic cinemaLogic = new CinemaLogic(unitOfWork.Object, cinemaMapper.Object);
            IEnumerable<Cinema.Model.Entity.Cinema> cinemaList = new List<Cinema.Model.Entity.Cinema>();
            unitOfWork.Setup(p => p.cinemaRepository.Get(null, null, ""))
                .Returns(cinemaList);

            //act
            var cinemas = cinemaLogic.GetCinemas();

            //assert
            Assert.NotNull(cinemas);
            Assert.Equal(0, cinemas.Count());
        }

        private List<Cinema.Model.Entity.Cinema> _GetCinemas()
        {
            List<Cinema.Model.Entity.Cinema> cinemas = new List<Cinema.Model.Entity.Cinema>
            {
                new Cinema.Model.Entity.Cinema
                {
                    Description = "Description 1",
                    Duration = 2.50M,
                    ID = 1,
                    Title = "Title1"
                },
                 new Cinema.Model.Entity.Cinema
                {
                    Description = "Description 2",
                    Duration = 3M,
                    ID = 2,
                    Title = "Title2"
                }
            };
            return cinemas;
        }
       
    }
}
