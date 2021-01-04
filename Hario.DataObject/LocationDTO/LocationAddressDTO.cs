namespace Hario.DataObject.LocationDTO
{
    public class LocationAddressDTO : BaseDTO
    {
        public CityDTO City { get; set; }
        public DistrictDTO District { get; set; }
        public string StreetAddress { get; set; }
    }
}
