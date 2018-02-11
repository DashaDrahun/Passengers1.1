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
    public class AddNewOrderWindowVM:ClientPageVM
    {
        Window window;
        public ClientViewModel client;
        private TripViewModel selectedtrip;
        private OrderViewModel order;
        private double priceoftrip;
        public ObservableCollection<TripViewModel> Trips { get; set; }
        public AddNewOrderWindowVM(Window window, ClientViewModel editclient):base("NewPasTransfDbConnection")
        {
            this.window = window;
            client = editclient;
            order = new OrderViewModel { Client = client };
            Trips = GetAvaliableTripsForClient();
            InitializeCommands();
        }
        public TripViewModel SelectedTrip
        {
            get { return selectedtrip; }
            set
            {
                if (value != null)
                {
                    selectedtrip = value;                    
                    OnPropertyChanged(nameof(SelectedTrip));
                    Priceoftrip = selectedtrip.Price;
                }
            }
        }

        public ICommand OkAddOrderCommand { get; set; }
        public ICommand CancelEditClientCommand { get; set; }

        public double Priceoftrip
        {
            get
            {
                return priceoftrip;
            }

            set
            {
                priceoftrip = value;
                OnPropertyChanged(nameof(Priceoftrip));
            }
        }

        private void InitializeCommands()
        {
            OkAddOrderCommand = new RelayCommand(p =>
            {
                if (selectedtrip != null && order.Client != null)
                {
                    order.Trip = selectedtrip;
                    order.SeatNumber = (byte)GetFreeSeatNumberForOrder(selectedtrip);
                    string info = "Информация о заказе:\nКлиент: " + order.Client + "\nРейс: " + order.Trip.Route + "\nДатаВремя Отправления: " + order.Trip.Arrival + "\nЦена: " + order.Trip.Price + "\nМесто: "+ order.SeatNumber + "\n(Нажмите Да для подтверждения оформления заказа\nИначе - нет";
                    var result1 = MessageBox.Show(info, "Подтверждение заказа", MessageBoxButton.YesNo);
                    if (result1 == MessageBoxResult.Yes)
                    {
                        CreateOrder(order);
                        window.DialogResult = true;
                    }
                }
                else window.DialogResult = false;

            }
            );

            CancelEditClientCommand = new RelayCommand(p =>
            {
                window.DialogResult = false;
            }
            );
        }
    }
}
