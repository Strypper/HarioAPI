using System.Collections.Generic;

namespace Hairo.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public ServiceType StoreService { get; set; }
        public ICollection<ChildService> ChildServices { get; set; }
    }

    public enum ServiceType
    {
        HairCut, HairCurling, HairShowser, SkinCare, Other
    }
}
