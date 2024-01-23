using System;
using System.Collections.Generic;

namespace Инд.проект.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public int CustomersCode { get; set; }
        public string Surname { get; set; } = null!;
        public string Forename { get; set; } = null!;
        public string PassportData { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public int LeaderNumberOfTheTrust { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
