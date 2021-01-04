using System;

namespace Hario.DataObject.LocationDTO
{
    public class LocationPhotoDTO : BaseDTO
    {
        public string LocationPhotoUrl { get; set; } = String.Empty;
        public DateTime UploadDate { get; set; }
    }
}
