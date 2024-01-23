using System;
using System.Collections.Generic;

namespace Инд.проект.Models
{
    public partial class PrivateFace
    {
        public int PrivateFaceCode { get; set; }
        public int AmenitiesCode { get; set; }
        public string Surname { get; set; } = null!;
        public string Forename { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Directions { get; set; } = null!;

        public virtual Amenity AmenitiesCodeNavigation { get; set; } = null!;
    }
}
