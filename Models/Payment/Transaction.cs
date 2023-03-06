using Airbnb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnbfinal.Models.Payment
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Booking))]
        public int ReservationId { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
