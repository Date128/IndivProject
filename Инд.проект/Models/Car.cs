using System;
using System.Collections.Generic;

namespace Инд.проект.Models
{
    public partial class Car
    {
        public Car()
        {
            Bookings = new HashSet<Booking>();
        }

        public int CarCode { get; set; }
        public string Model { get; set; } = null!;
        public DateTime ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfEntryToTheDatabase { get; set; }
        public DateTime DateOfIssueOfTheDatabase { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
