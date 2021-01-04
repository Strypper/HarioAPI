using System;
using System.Collections.Generic;
using System.Text;

namespace Hario.DataObject
{
    public class ChildServiceDTO : BaseDTO
    {
        public string ChildServiceName { get; set; }
        public decimal Price { get; set; }
        public ICollection<ChildServicePhotoDTO> ChildServicePhotos { get; set; }
    }
}
