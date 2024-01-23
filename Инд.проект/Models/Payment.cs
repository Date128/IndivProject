using System;
using System.Collections.Generic;

namespace Инд.проект.Models
{
    public partial class Payment
    {
        public int PaymentCode { get; set; }
        public int BookingCode { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Booking BookingCodeNavigation { get; set; } = null!;
    }
}
