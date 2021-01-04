using System;
using System.Collections.Generic;
using System.Text;

namespace Hairo.Entities.Location
{
    public class LocationAddress : BaseEntity
    {
        public District District { get; set; }
        public City City { get; set; }
        public string StreetAddress { get; set; }
    }
}
