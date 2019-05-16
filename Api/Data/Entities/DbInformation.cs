using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
    public class DbInformation
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int NumberOfPeople { get; set; }
        public Guid PlaceId { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public DbPlace Place { get; set; }
    }
}
