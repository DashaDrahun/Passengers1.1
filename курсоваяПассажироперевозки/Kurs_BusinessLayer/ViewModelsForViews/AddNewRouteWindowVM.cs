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
    public class AddNewRouteWindowVM:RoutePageVM
    {
        private CityViewModel selectedcitydep;
        private CityViewModel selectedcityarr;
        private string kilometress;
        public double temp;
        Window window;       
        public RouteViewModel route = new RouteViewModel();
        public ObservableCollection<CityViewModel> Cities { get; set; }  
        public ObservableCollection<RouteViewModel> Routes { get; set; }
        public AddNewRouteWindowVM(Window window) : base("NewPasTransfDbConnection")
        {
            this.window = window;
            Routes = this.Allroutes;
            Cities = GetAllCitiesForRoute();
            InitializeCommands();
        }
        
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

        public ICommand OkAddRouteCommand { get; set; }
        public ICommand CancelAddRouteCommand { get; set; }

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
                if (SelectedCityArr!=null && SelectedCityDep!= null && SelectedCityArr != SelectedCityDep)
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
                    foreach (var route in Routes)
                    {
                        if (route.CityDepart.Name== SelectedCityDep.Name && route.CityArr.Name==SelectedCityArr.Name)
                        {
                            MessageBox.Show("Такой маршрут уже существует!");
                            return;
                        }                            
                    }
                    this.CreateRoute(new RouteViewModel
                    {
                        
                        CityArr = route.CityArr,
                        CityDepart = route.CityDepart,
                        Kilometres = temp,

                    });
                }
                else { MessageBox.Show("Введите значения городов! Город назначения и город направления не должны совпадать!"); return; }
                window.DialogResult = true;
            }
            );

            CancelAddRouteCommand = new RelayCommand(p =>
            {
                window.DialogResult = false;
            }
            );
        }
    }
}
