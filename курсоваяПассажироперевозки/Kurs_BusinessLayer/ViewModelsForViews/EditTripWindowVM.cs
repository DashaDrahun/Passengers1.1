using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using Kurs_BusinessLayer.Services;
using System.Windows.Input;
using Kurs_BusinessLayer.Helpers;
using Kurs_BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    class EditTripWindowVM:TripPageVM
    {
        Window window;
        private RouteViewModel selectedroute;
        private StatusViewModel selectedstatus;
        public TripViewModel trip;
        private string price;
        private string freeseats;
        public ObservableCollection<RouteViewModel> Routes { get; set; }
        public ObservableCollection<StatusViewModel> Statuses { get; set; }
        public EditTripWindowVM(Window window, TripViewModel edittrip) : base("NewPasTransfDbConnection")
        {
            this.window = window;
            Routes = GetAllRoutesForTrip();
            Statuses = GetAllStatusesForTrip();
            trip = edittrip;
            InitializeCommands();
        }

        public ICommand OkEditTripCommand { get; set; }
        public ICommand CancelEditTripCommand { get; set; }

        public RouteViewModel SelectedRoute
        {
            get { return selectedroute; }
            set
            {
                selectedroute = value;
                trip.Route = selectedroute;
                OnPropertyChanged(nameof(SelectedRoute));
            }
        }

        public StatusViewModel SelectedStatus
        {
            get
            {
                return selectedstatus;
            }

            set
            {
                selectedstatus = value;
                trip.Status = selectedstatus;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }

        public string Price
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

        public string Freeseats
        {
            get
            {
                return freeseats;
            }

            set
            {
                freeseats = value;
                OnPropertyChanged(nameof(Freeseats));
            }
        }

        private void InitializeCommands()
        {
            OkEditTripCommand = new RelayCommand(p =>
            {
                if (trip.Arrival!=null && trip.Departure!=null && trip.Route!=null && trip.Status!=null)
                {
                    try
                    {
                        trip.Price = Convert.ToDouble(Price);
                    }
                    catch
                    {
                        System.Windows.MessageBox.Show("Некорретный ввод цены. Повторите попытку");
                        return;
                    }
                    try
                    {
                        trip.FreeSeetsNumber = Convert.ToByte(Freeseats);
                    }
                    catch
                    {
                        System.Windows.MessageBox.Show("Некорретный ввод свободных мест. Повторите попытку");
                        return;
                    }
                    //trip.Status = Statuses[0];
                    this.UpdateTrip(trip);
                }
                window.DialogResult = true;
            }
            );

            CancelEditTripCommand = new RelayCommand(p =>
            {
                window.DialogResult = false;
            }
            );
        }
    }
}
