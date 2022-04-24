using CMS.API.Models;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public interface ICabService
    {
        Task<int> AddCabAsync(Cab cab);

        Task<bool> DisableCabAsync(int cabId);

        Task<bool> EnableCabAsync(int cabId);

        Task<bool> UpdateCabDetailsAsync(int cabId, Cab cabDetails);

        Task<Cab> GetCabAsync(int cityId);
    }
}
