using UserCarManagementAPI.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCarManagementAPI.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<List<CarDTO>> GetCarList();
        Task<CarReferenceViewModel> CarRefernceList();
        Task<CarDTO> GetCarById(int carId);
    }
}
