using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kurs_DataLayer.Entities
{
    public class Status
    {
        public Status()
        {
            this.Trips = new HashSet<Trip>();
            this.Orders = new HashSet<Order>();
        }
        public int StatusId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
