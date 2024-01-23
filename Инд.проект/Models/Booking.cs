using System;
using System.Collections.Generic;

namespace Инд.проект.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public int BookingCode { get; set; }
        public int CarCode { get; set; }
        public int CustomersCode { get; set; }
        public int AmenitiesCode { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime DateOfTerminationOfBooking { get; set; }
        public double ReservationCost { get; set; }
        public bool BookingStatus { get; set; }

        public virtual Amenity AmenitiesCodeNavigation { get; set; } = null!;
        public virtual Car CarCodeNavigation { get; set; } = null!;
        public virtual Customer CustomersCodeNavigation { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
