using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.Models
{
    public class TripViewModel:BaseVM
    {
        private int tripId;
        private System.DateTime arrival;
        private System.DateTime departure;
        private byte freeSeetsNumber;
        private double price;
        private RouteViewModel route;
        private StatusViewModel status;
       // public ObservableCollection<OrderViewModel> Orders { get; set; }

        public int TripId
        {
            get
            {
                return tripId;
            }

            set
            {
                tripId = value;
                OnPropertyChanged(nameof(TripId));
            }
        }

        public DateTime Arrival
        {
            get
            {
                return arrival;
            }

            set
            {
                arrival = value;
                OnPropertyChanged(nameof(Arrival));
            }
        }

        public DateTime Departure
        {
            get
            {
                return departure;
            }

            set
            {
                departure = value;
                OnPropertyChanged(nameof(Departure));
            }
        }

        public byte FreeSeetsNumber
        {
            get
            {
                return freeSeetsNumber;
            }

            set
            {
                freeSeetsNumber = value;
                OnPropertyChanged(nameof(FreeSeetsNumber));
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public RouteViewModel Route
        {
            get
            {
                return route;
            }

            set
            {
                route = value;
                OnPropertyChanged(nameof(Route));
            }
        }

        public StatusViewModel Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public override string ToString()
        {
            return Route + " " + Arrival;
        }
    }
}
