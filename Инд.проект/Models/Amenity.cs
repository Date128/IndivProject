using System;
using System.Collections.Generic;

namespace Инд.проект.Models
{
    public partial class Amenity
    {
        public Amenity()
        {
            Bookings = new HashSet<Booking>();
            CarRentalAgencies = new HashSet<CarRentalAgency>();
            PrivateFaces = new HashSet<PrivateFace>();
        }

        public int AmenitiesCode { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CarRentalAgency> CarRentalAgencies { get; set; }
        public virtual ICollection<PrivateFace> PrivateFaces { get; set; }
    }
}
