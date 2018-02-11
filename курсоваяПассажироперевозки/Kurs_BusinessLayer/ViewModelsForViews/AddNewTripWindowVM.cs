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
using Xceed.Wpf.Toolkit;

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    class AddNewTripWindowVM:TripPageVM
    {
        Window window;
        private RouteViewModel selectedroute;
        private string price;
        private string freeseats;
        public TripViewModel trip = new TripViewModel();
        public ObservableCollection<RouteViewModel> Routes { get; set; }
        public ObservableCollection<StatusViewModel> Statuses { get; set; }
        public AddNewTripWindowVM(Window window) : base("NewPasTransfDbConnection")
        {
            this.window = window;
            Routes = GetAllRoutesForTrip();
            Statuses= GetAllStatusesForTrip();
            InitializeCommands();
        }

        public ICommand OkAddTripCommand { get; set; }
        public ICommand CancelAddTripCommand { get; set; }

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
            OkAddTripCommand = new RelayCommand(p =>
            {
                if (trip.Arrival!=null && trip.Departure!=null && trip.Route!=null)
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

                    trip.Status = Statuses[0];
                    this.CreateTrip(trip);
                }
                else { System.Windows.MessageBox.Show("Введите маршрут, время отправления и время прибытия"); return; }
                window.DialogResult = true;
            }
            );

            CancelAddTripCommand = new RelayCommand(p =>
            {
                window.DialogResult = false;
            }
            );
        }
    }
}
