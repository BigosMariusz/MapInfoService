using Generator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class Sender
    {
        public async Task SendDataAsync()
        {
            var generator = new DataGenerator();
            List<DataFormat> data = generator.Generate();

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            StringContent queryString = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                await client.PostAsync(new Uri("https://localhost:44379/api/generator"), queryString);
            }
        }
    }
}
