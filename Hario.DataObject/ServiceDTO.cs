using System;
using System.Collections.Generic;
using System.Text;

namespace Hario.DataObject
{
    public class ServiceDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public ServiceTypeDTO StoreService { get; set; }
        public ICollection<ChildServiceDTO> ChildServicesDTO { get; set; }
    }
    public enum ServiceTypeDTO
    {
        HairCut, HairCurling, HairShowser, SkinCare, Other
    }
}
