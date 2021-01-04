using System.Collections.Generic;

namespace Hairo.Entities
{
    public class ChildService : BaseEntity
    {
        public string ChildServiceName { get; set; }
        public decimal Price { get; set; }
        public ICollection<ChildServicePhoto> ChildServicePhotos { get; set; }
    }
}
