using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs_DataLayer.Entities
{
    public class Route
    {
        public Route()
        {
            this.Trips = new HashSet<Trip>();
        }
        public int RouteId { get; set; }
        [Required]
        public double Kilometres { get; set; }      
        public int CityArrId { get; set; }       
        public int CityDepartId { get; set; }
        [Required]
        [ForeignKey("CityDepartId")]
        public virtual City CityDepart { get; set; }
        [Required]
        [ForeignKey("CityArrId")]
        public virtual City CityArr { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }

    }
}
