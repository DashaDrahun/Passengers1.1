using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_BusinessLayer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Kurs_BusinessLayer.Models;
using Kurs_DataLayer.Repositories;
using Kurs_DataLayer.Entities;
using System.Windows.Input;
using Kurs_BusinessLayer.Helpers;
using Kurs_BusinessLayer.WindowHelpers;
using System.Windows.Data;
using System.Windows;
using System.Threading;

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    public class RoutePageVM:RouteService, INotifyPropertyChanged
    {
        private ObservableCollection<RouteViewModel> allroutes;
        public ObservableCollection<RouteViewModel> Allroutes
        {
            get
            {
                return allroutes;
            }

            set
            {
                allroutes = value;
                OnPropertyChanged("Allroutes");
            }
        }
        private RouteViewModel selectedroute;
        public RouteViewModel SelectedRoute
        {
            get { return selectedroute; }

            set
            {
                selectedroute = value;
                OnPropertyChanged("SelectedRoute");
            }

        }
        public RoutePageVM(string name) : base(name)
        {
            Allroutes = GetAll();
            InitializeCommands();
        }

        public ICommand AddRouteCommand { get; set; }
        public ICommand DeleteRouteCommand { get; set; }
        public ICommand EditRouteCommand { get; set; }


        private void InitializeCommands()
        {

            EditRouteCommand = new RelayCommand(p =>
            {
                if (selectedroute != null)
                {
                    EditRouteWindow window = new EditRouteWindow(selectedroute);
                    if (window.ShowDialog() == true)
                    {
                       // Allroutes = this.GetAll();
                    }
                    else
                    {
                       Allroutes = this.GetAll();
                    }
                }
            });

            AddRouteCommand = new RelayCommand(p =>
            {
                AddNewRouteWindow window = new AddNewRouteWindow();
                if (window.ShowDialog() == true)
                {
                    Allroutes = this.GetAll();

                }

            });

            DeleteRouteCommand = new RelayCommand(p =>
            {
                if (selectedroute != null)
                {
                    if (SelectedRoute.Trips.Count > 0)
                    {
                        foreach (var trip in SelectedRoute.Trips)
                        {
                            if (trip.Departure.Day>=DateTime.Now.Day && trip.Departure.Month>=DateTime.Now.Month && trip.Departure.Year>=DateTime.Now.Year)
                            {
                                MessageBox.Show("У маршрута есть действующие рейсы! Не подлежит изменению");
                                return;
                            }
                        }
                        var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            DeleteRoute(selectedroute);
                            Allroutes = this.GetAll();
                        }
                    }

                }
            });
        }



        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
