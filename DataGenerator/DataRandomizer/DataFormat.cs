using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class DataFormat
    {
        public Guid PlaceId { get; set; }
        public int NumberOfPeople { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }
}
