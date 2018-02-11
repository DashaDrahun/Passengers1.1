using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs_DataLayer.Entities
{
    public class City
    {
        public City()
        {
            this.RoutesArr = new HashSet<Route>();
            this.RoutesDep = new HashSet<Route>();
        }
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        [InverseProperty("CityDepart")]
        public virtual ICollection<Route> RoutesDep { get; set; }
        [InverseProperty("CityArr")]
        public virtual ICollection<Route> RoutesArr { get; set; }
    }
}
