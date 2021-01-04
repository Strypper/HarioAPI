using Hairo.Entities.Location;
using System;
using System.Collections.Generic;

namespace Hairo.Entities
{
    public class Store : BaseEntity
    {
        public string Brand { get; set; }
        public ICollection<LocationAddress> Locations { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime{ get; set; }
        public string BrandUrl { get; set; } = String.Empty;
        public double? StoreRating { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<LocationPhoto> LocationPhotos { get; set; }
    }
}
