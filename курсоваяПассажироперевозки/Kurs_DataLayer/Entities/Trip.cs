using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Kurs_DataLayer.Entities
{
    public class Trip
    {
        public Trip()
        {
            this.Orders = new HashSet<Order>();
        }
        public int TripId { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        [Required]
        public System.DateTime Arrival { get; set; }
        [Required]
        public System.DateTime Departure { get; set; }
        [Required]
        public byte FreeSeetsNumber { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public virtual Route Route { get; set; }
        [Required]
        public virtual Status Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
