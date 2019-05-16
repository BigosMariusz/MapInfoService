using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Initialize
{
    public class InitializePlaces
    {
        public static async Task InitializeData(MapContext context)
        {
            context.Database.Migrate();

            if (!context.Places.Any())
            {
                var places = new DbPlace[]
                {
                    new DbPlace
                    {
                        Latitude = 50.029528,
                        Longitude = 22.000863,
                        Name = "Hala Sportowa",
                        Category = "Sport"
                    },
                    new DbPlace
                    {
                        Latitude = 50.037055, 
                        Longitude = 22.008595,
                        Name = "Studnia Rzeszów",
                        Category = "Rozrywka"
                    },
                    new DbPlace
                    {
                        Latitude = 50.044517, 
                        Longitude = 21.974477,
                        Name = "Pływalnia Karpik",
                        Category = "Sport"
                    },
                    new DbPlace
                    {
                        Latitude = 50.024578, 
                        Longitude = 21.969367,
                        Name = "Biedronka Przemysłowa",
                        Category = "Sklep"
                    },
                    new DbPlace
                    {
                        Latitude = 50.018509, 
                        Longitude = 21.973486,
                        Name = "Lidl Podkarpacka",
                        Category = "Sklep"
                    },
                    new DbPlace
                    {
                        Latitude = 50.023154, 
                        Longitude = 22.007819,
                        Name = "Basen Delfin",
                        Category = "Sport"
                    },
                    new DbPlace
                    {
                        Latitude = 50.036304, 
                        Longitude = 22.006844,
                        Name = "Klub piekiełko",
                        Category = "Rozrywka"
                    },
                    new DbPlace
                    {
                        Latitude = 50.038897, 
                        Longitude = 22.005191,
                        Name = "Klub pod zdechłym kotem",
                        Category = "Rozrywka"
                    },
                    new DbPlace
                    {
                        Latitude = 50.038085, 
                        Longitude = 22.012033,
                        Name = "Klub Disco Polo",
                        Category = "Rozrywka"
                    },
                    new DbPlace
                    {
                        Latitude = 50.044226, 
                        Longitude = 21.995359,
                        Name = "Kawiarnia pod jeżozwierzem",
                        Category = "Rozrywka"
                    }
                };
                context.Places.AddRange(places);
                await context.SaveChangesAsync();
            }
        }
    }
}
