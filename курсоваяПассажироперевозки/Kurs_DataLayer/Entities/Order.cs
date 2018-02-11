using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Kurs_DataLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Trip")]
        public int TripId { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Required]
        public virtual Client Client { get; set; }
        [Required]
        public virtual Trip Trip { get; set; }
        [Required]
        public virtual Status Status { get; set; }
        [Required]
        public byte SeatNumber { get; set; }


    }
}
