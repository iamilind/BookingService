using CMS.API.Models;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class CabService : ICabService
    {
        public Task<int> AddCabAsync(Cab cab)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DisableCabAsync(int cabId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EnableCabAsync(int cabId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cab> GetCabAsync(int cityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateCabDetailsAsync(int cityId, Cab cabDetails)
        {
            throw new System.NotImplementedException();
        }
    }
}
