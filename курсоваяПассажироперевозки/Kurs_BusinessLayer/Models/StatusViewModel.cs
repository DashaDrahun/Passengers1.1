using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.Models
{
    public class StatusViewModel:BaseVM
    {
        private int statusId;
        private string name;
        //public ObservableCollection<TripViewModel> Trips { get; set; }
        //public ObservableCollection<OrderViewModel> Orders { get; set; }

        public int StatusId
        {
            get
            {
                return statusId;
            }

            set
            {
                statusId = value;
                OnPropertyChanged(nameof(StatusId));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
