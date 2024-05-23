using UserCarManagementAPI.Domain;
using UserCarManagementAPI.Domain.Identity;
using UserCarManagementAPI.Domain.Interfaces;
using UserCarManagementAPI.UserInfra.Exceptions;
using UserCarManagementAPI.UserInfra.Mapping;

namespace UserCarManagementAPI.UserInfra.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly MapperData _mapperData;
        public CarRepository(MapperData mapperData)
        {
            //this._dbContext = dbContext;
            this._mapperData = mapperData;
        }
        public async Task<List<CarDTO>> GetCarList()
        {
            List<CarDTO> carDTOs = await _mapperData.CarInfoDetails();
            return carDTOs;
        }
        public async Task<CarReferenceViewModel> CarRefernceList()
        {
            CarReferenceViewModel carReferenceView = new CarReferenceViewModel();

            carReferenceView = await _mapperData.GetCarReferenceDataList();
            return carReferenceView;
        }

        public async Task<CarDTO> GetCarById(int id)
        {
            CarDTO carDTO = new CarDTO();
            var result = await _mapperData.GetCarById(id);
            if (result == null)
            {
                throw new NotFoundException(nameof(ResponseStatus), "Data not found", "");
            }
            return result;
        }
    }
}
