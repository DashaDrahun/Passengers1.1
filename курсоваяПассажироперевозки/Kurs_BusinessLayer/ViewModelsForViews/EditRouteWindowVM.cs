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
    public class EditRouteWindowVM : RoutePageVM
    {
        Window window;
        private CityViewModel selectedcitydep;
        private CityViewModel selectedcityarr;
        private string kilometress;
        public double temp;
        public ObservableCollection<CityViewModel> Cities { get; set; }
        public ObservableCollection<RouteViewModel> Routes { get; set; }
        public RouteViewModel route = new RouteViewModel();
        public EditRouteWindowVM(Window window, RouteViewModel editroute) : base("NewPasTransfDbConnection")
        {
            this.window = window;
            Cities = GetAllCitiesForRoute();
            Routes = this.Allroutes;
            route = editroute;
            InitializeCommands();
        }

        public ICommand OkAddRouteCommand { get; set; }
        public ICommand CancelAddRouteCommand { get; set; }

        public CityViewModel SelectedCityDep
        {
            get { return selectedcitydep; }
            set
            {
                selectedcitydep = value;
                route.CityDepart = selectedcitydep;
                OnPropertyChanged(nameof(SelectedCityDep));
            }
        }

        public CityViewModel SelectedCityArr
        {
            get { return selectedcityarr; }
            set
            {
                selectedcityarr = value;
                route.CityArr = selectedcityarr;
                OnPropertyChanged(nameof(SelectedCityArr));
            }
        }
        public string Kilometress
        {
            get
            {
                return kilometress;
            }

            set
            {
                
                kilometress = value;
                OnPropertyChanged(nameof(Kilometress));
            }
        }

        private void InitializeCommands()
        {
            OkAddRouteCommand = new RelayCommand(p =>
            {
                if (route.Trips.Count>0)
                {
                    MessageBox.Show("У маршрута есть рейсы! Не подлежит изменению");                    
                    //window.DialogResult = false;
                    return;
                }
                if (SelectedCityArr != null && SelectedCityDep != null && SelectedCityArr != SelectedCityDep)
                {
                    try
                    {
                        temp = Convert.ToDouble(Kilometress);

                    }
                    catch
                    {
                        MessageBox.Show("Введите корректное значение километров");
                        return;
                    }
                    route.Kilometres = temp;
                    UpdateRoute(route);
                }
                else { MessageBox.Show("Введите значения городов! Город назначения и город направления не должны совпадать!"); return; }
                window.DialogResult = true;
            });

            CancelAddRouteCommand = new RelayCommand(p =>
            {
                window.DialogResult = false;
            }
            );
        }
    }
}
