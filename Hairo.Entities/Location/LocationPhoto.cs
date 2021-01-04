using System;
using System.Collections.Generic;
using System.Text;

namespace Hairo.Entities.Location
{
    public class LocationPhoto : BaseEntity
    {
        public string LocationPhotoUrl { get; set; } = String.Empty;
        public DateTime UploadDate { get; set; }
    }
}
