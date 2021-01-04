using Hario.DataObject.LocationDTO;
using System;
using System.Collections.Generic;

namespace Hario.DataObject
{
    public class StoreDTO : BaseDTO
    {
        public string Brand { get; set; }
        public ICollection<LocationAddressDTO> Locations { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string BrandUrl { get; set; } = String.Empty;
        public double? StoreRating { get; set; }
        public ICollection<ServiceDTO> Services { get; set; }
        public ICollection<LocationPhotoDTO> LocationPhotos { get; set; }
    }
}
