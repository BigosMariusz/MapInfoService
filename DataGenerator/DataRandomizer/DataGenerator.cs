using Generator;
using MathNet.Numerics.Distributions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Generator
{
    public class DataGenerator
    {
        public List<DataFormat> Generate()
        {
            var idList = GetIdList();
            var numberOfPlaces = idList.Count;
            var randomeData = new List<DataFormat>();

            foreach (Guid id in idList)
            {
                var newInformation = new DataFormat()
                {
                    PlaceId = id,
                    NumberOfPeople = GetRandomValue(10,300),
                    Temperature = GetRandomValue(15,25),
                    Humidity = GetRandomValue(50,100)
                };
                randomeData.Add(newInformation);
            }
            return randomeData;
        }

        private List<Guid> GetIdList()
        {
            string json;
            using (var client = new WebClient())
            {
                json = client.DownloadString("https://localhost:44379/api/generator");
            }
            List<Guid> idList = JsonConvert.DeserializeObject<List<Guid>>(json);
            return idList;
        }

        private int GetRandomValue(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}
