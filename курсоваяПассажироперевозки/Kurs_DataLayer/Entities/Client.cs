using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Kurs_DataLayer.Entities
{
    public class Client
    {
        public Client()
        {
            this.Orders = new HashSet<Order>();
        }
        public int ClientId { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Column(TypeName = "date")]
        public System.DateTime DateBirth { get; set; }
        [Required]
        public string Tel_Mobile { get; set; }
        public string Email { get; set; }
        public string VKProfile { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
