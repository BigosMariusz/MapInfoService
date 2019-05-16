using Data;
using System;
using System.Threading.Tasks;
using ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using Newtonsoft.Json;

namespace BusinessLogic
{
    public class GeneratorService : IGeneratorService
    {
        private readonly MapContext _context;

        public GeneratorService(MapContext context)
        {
            _context = context;
        }

        public async Task AddPointsInfoAsync(List<VMAddPointsInfo> info)
        {
            foreach(var information in info)
            {
                var pointInfo = new DbInformation()
                {
                    TimeStamp = DateTime.Now,
                    NumberOfPeople = information.NumberOfPeople,
                    PlaceId = information.PlaceID,
                    Temperature = information.Temperature,
                    Humidity = information.Humidity
                };
                await _context.Informations.AddAsync(pointInfo);
            }
            _context.SaveChanges();
        }

        public async Task<List<Guid>> GetPlaceIdsAsync()
        {
            return await _context.Places.Where(x => x.Id != Guid.Empty).Select(x => x.Id).ToListAsync();
        }
    }
}
