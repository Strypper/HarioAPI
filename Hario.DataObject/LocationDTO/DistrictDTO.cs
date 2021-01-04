using System;

namespace Hario.DataObject.LocationDTO
{
    public class DistrictDTO : BaseDTO
    {
        public string DistrictName { get; set; } = String.Empty;
        public CityDTO City { get; set; }
    }
}
