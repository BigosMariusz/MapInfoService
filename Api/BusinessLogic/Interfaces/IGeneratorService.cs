using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLogic.Interfaces
{
    public interface IGeneratorService
    {
        Task AddPointsInfoAsync(List<VMAddPointsInfo> info);
        Task<List<Guid>> GetPlaceIdsAsync();
    }
}
