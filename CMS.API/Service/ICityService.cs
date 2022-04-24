using CMS.API.Models;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public interface ICityService
    {
        Task<int> AddCityAsync(City city);

        Task<bool> DisableCityAsync(int cityId);

        Task<bool> EnableCityAsync(int cityId);

        Task<bool> UpdateCityAsync(int cityId, City city);

        Task<City> GetCityAsync(int cityId);
    }
}
