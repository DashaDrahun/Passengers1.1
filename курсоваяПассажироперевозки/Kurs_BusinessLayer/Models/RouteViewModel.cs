using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.Models
{
    public class RouteViewModel:BaseVM
    {
        private int routeId;
        private double kilometres;
        private CityViewModel citydepart;
        private CityViewModel cityarr;

        public ObservableCollection<TripViewModel> Trips { get; set; }

        public int RouteId
        {
            get
            {
                return routeId;
            }

            set
            {
                routeId = value;
                OnPropertyChanged(nameof(RouteId));
            }
        }       

        public double Kilometres
        {
            get
            {
                return kilometres;
            }

            set
            {
                kilometres = value;
                OnPropertyChanged(nameof(Kilometres));
            }
        }

        public CityViewModel CityDepart
        {
            get
            {
                return citydepart;
            }

            set
            {
                citydepart = value;
                OnPropertyChanged(nameof(CityDepart));

            }
        }

        public CityViewModel CityArr
        {
            get
            {
                return cityarr;
            }

            set
            {
                cityarr = value;
                OnPropertyChanged(nameof(CityArr));
            }
        }
        public override string ToString()
        {
            return citydepart.Name + " - " + cityarr.Name;
        }
    }
}
