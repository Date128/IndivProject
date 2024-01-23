using System;
using System.Collections.Generic;

namespace Инд.проект.Models
{
    public partial class CarRentalAgency
    {
        public int AgencyCode { get; set; }
        public int AmenitiesCode { get; set; }
        public string ContactNumberOfTheAgency { get; set; } = null!;
        public string Directions { get; set; } = null!;
        public string AgencyName { get; set; } = null!;
        public string AgencysWebsite { get; set; } = null!;
        public TimeSpan HoursOfWork { get; set; }

        public virtual Amenity AmenitiesCodeNavigation { get; set; } = null!;
    }
}
