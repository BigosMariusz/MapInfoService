using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class VMGetPlaces
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
