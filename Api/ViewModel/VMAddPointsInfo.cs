using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class VMAddPointsInfo
    {
        public Guid PlaceID { get; set; }
        public int NumberOfPeople { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }
}
