using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCarManagementAPI.Controllers;
using UserCarManagementAPI.Domain;
using UserCarManagementAPI.Domain.Interfaces;

namespace xUnitUserCarManagementAPI.Controller
{
    public class UserCarInfoControllerUnitTest
    {

        private Mock<ICarRepository> _carRepository;
        public UserCarInfoControllerUnitTest()
        {
            this._carRepository = new Mock<ICarRepository>();
        }
        [Fact]
        public void GetCarList_onSuccess()
        {
            //Arrange
            var carList = GetCarList().Result;
            _carRepository.Setup(x => x.GetCarList()).ReturnsAsync(carList);
            var carController = new UserCarInfoController(_carRepository.Object);

            //act
            var carResult = carController.GetCarDetails();

            //assert
            Assert.NotNull(carResult);
            Assert.Equal(carList.Count(), carResult.Result.Count());
            Assert.Equal(GetCarList().ToString(), carResult.ToString());
            Assert.True(carList.Equals(carResult.Result));
        }

        private async Task<List<CarDTO>> GetCarList()
        {
            List<CarDTO> carList = new List<CarDTO>
            {
                new CarDTO
                {
                    Id = 7,
                carname = "Suzki",
                carImage = "425c51e2-088c-4531-8812-30edf2dd7e59.jpg",
                carModel = "BH62",
                manifactureId = 1,
                typeId = 2,
                engine = "BHU72",
                BHP = 12,
                carTransmissionId = 1,
                mileage = 10,
                seat = 4,
                airBagDetails = "Driver Side",
                bootspace = "Long",
                price = 234567,
                manufacturerName = "Suzuki",
                CarTransmissionTypeName = "manual",
                type = "Sedan",
                contactPerson = "Dileep Dello",
                registeredOffice = "Dello Enterp",
                manufacturer = new Manufacturer
                {
                    id = 1,
                    name = "Suzuki",
                    contactPerson = "Dileep Dello",
                    registeredOffice = "Dello Enterp"
                },
                carTransmissionType = new CarTransmissionType
                {
                    id = 1,
                    name = "manual"
                },

                 CarType = new CarType
                 {
                    id =2,
                    type = "Sedan"
                 }

                }


            };

            return carList;

        }

    }
}
