using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCarManagementAPI.Domain;
using UserCarManagementAPI.Domain.Identity;
using UserCarManagementAPI.Domain.Interfaces;

namespace UserCarManagementAPI.Controllers
{
    [Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserCarInfoController : ControllerBase
    {
        private ICarRepository _carRepository;
        public UserCarInfoController(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
        [HttpGet("GetCarsFromUser")]
        public async Task<List<CarDTO>> GetCarDetails()
        {
            var GetCarInfo = await _carRepository.GetCarList();
            return GetCarInfo;

        }
        [HttpGet("CarRefernceListFromUser")]
        public async Task<CarReferenceViewModel> GetCarRefernceList()
        {
            var carReference = await _carRepository.CarRefernceList();
            return carReference;

        }
        [HttpGet("GetCarByIdFromUser")]
        public async Task<ActionResult> GetCarById(int id)
        {
            var GetCarInfo = await _carRepository.GetCarById(id);
            return Ok(GetCarInfo);

        }
    }
}
