using Data;
using System;
using System.Threading.Tasks;
using ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace BusinessLogic
{
    public class MapService : IMapService
    {
        private readonly MapContext _context;

        public MapService(MapContext context)
        {
            _context = context;
        }
        public List<VMGetInfo> GetInfoSync()
        {
            //Bierze informacje dla wszystkich miejsc, także tych, które mogą być już usunięte, do poprawy
            List<DbInformation> infoList = _context.Informations
                .FromSql(@"select i.""Id"", i.""TimeStamp"", i.""NumberOfPeople"", i.""PlaceId"", i.""Temperature"", i.""Humidity"" 
                    from ""Informations"" i 
                    inner join(select ""PlaceId"", max(""TimeStamp"") as MaxDate 
                    from ""Informations"" group by ""PlaceId"") 
                    inf on i.""PlaceId"" = inf.""PlaceId"" and i.""TimeStamp"" = inf.MaxDate")
                    .ToList();

            List<VMGetInfo> infoListVM = new List<VMGetInfo>();
            foreach (DbInformation info in infoList)
            {
                var newInfoVM = new VMGetInfo()
                {
                    PlaceId = info.PlaceId,
                    NumberOfPeople = info.NumberOfPeople,
                    Temperature = info.Temperature,
                    Humidity = info.Humidity
                };
                infoListVM.Add(newInfoVM);
            }
            return infoListVM;
        }
        public async Task<List<VMGetPlaces>> GetPlacesAsync()
        {
            var dbPlaces = await _context.Places.Where(x => x.Id != Guid.Empty).ToListAsync();

            List<VMGetPlaces> placesList = new List<VMGetPlaces>();
            foreach(var place in dbPlaces)
            {
                var newPlace = new VMGetPlaces()
                {
                    Id = place.Id,
                    Latitude = place.Latitude,
                    Longitude = place.Longitude,
                    Name = place.Name,
                    Category = place.Category
                };
                placesList.Add(newPlace);
            }
            return placesList;
        }
    }
}
