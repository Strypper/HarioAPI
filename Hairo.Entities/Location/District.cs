using System;
using System.Collections.Generic;
using System.Text;

namespace Hairo.Entities.Location
{
    public class District : BaseEntity
    {
        public string DistrictName { get; set; } = String.Empty;
        public City City { get; set; }
    }
}
