using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLogic.Interfaces
{
    public interface IMapService
    {
        List<VMGetInfo> GetInfoSync();
        Task<List<VMGetPlaces>> GetPlacesAsync();
    }
}
