using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.Models
{
    public class OrderViewModel:BaseVM
    {
        private int orderId;
        private byte seatNumber;
        private ClientViewModel client;
        private TripViewModel trip;
        private StatusViewModel status;
        public int OrderId
        {
            get
            {
                return orderId;
            }

            set
            {
                orderId = value;
                OnPropertyChanged(nameof(OrderId));
            }
        }

        public byte SeatNumber
        {
            get
            {
                return seatNumber;
            }

            set
            {
                seatNumber = value;
                OnPropertyChanged(nameof(SeatNumber));
            }
        }

        public ClientViewModel Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        public TripViewModel Trip
        {
            get
            {
                return trip;
            }

            set
            {
                trip = value;
                OnPropertyChanged(nameof(Trip));
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
    }
}
