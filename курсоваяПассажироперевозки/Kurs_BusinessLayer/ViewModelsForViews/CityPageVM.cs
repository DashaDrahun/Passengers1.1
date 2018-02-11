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
using Kurs_BusinessLayer.Pages;
using System.Windows.Data;
using System.Windows;
using System.Threading;

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    public class CityPageVM : CityService, INotifyPropertyChanged
    {
        private ObservableCollection<CityViewModel> allcities;
        public ObservableCollection<CityViewModel> Allcities
        {
            get
            {
                return allcities;
            }

            set
            {
                allcities = value;
                OnPropertyChanged("Allcities");
            }
        }

        private CityViewModel selectedcity;
        public CityViewModel SelectedCity
        {
            get { return selectedcity; }

            set
            {
                if (value!=null)
                {
                selectedcity = value;
                OnPropertyChanged("SelectedCity");
                }
                
            }

        }
        public CityPageVM(string name):base(name)
        {
            Allcities=this.GetAll();
            InitializeCommands();
        }


        public ICommand AddCityCommand { get; set; }
        public ICommand DeleteCityCommand { get; set; }
        public ICommand EditCityCommand { get; set; }
        public ICommand ShowOrderCommand { get; set; }

        private void InitializeCommands()
        {
            EditCityCommand = new RelayCommand(p =>
            {
               if (selectedcity != null)
                {
                    EditCityWindow orderWindow = new EditCityWindow(SelectedCity);
                    if (orderWindow.ShowDialog() == true)
                    {
                        //Allcities = this.GetAll();
                    }
                }
                else MessageBox.Show("Для данной операции выделите строку в таблице");
            });

            AddCityCommand = new RelayCommand(p =>
            {
                AddNewCityWindow window = new AddNewCityWindow();
                
                if (window.ShowDialog() == true)
                {
                    Allcities = this.GetAll();

                }

            });

            DeleteCityCommand = new RelayCommand(p =>
            {
                if (selectedcity != null)
                {
                    var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DeleteCity(selectedcity);
                        Allcities = this.GetAll();
                    }
                }
                else MessageBox.Show("Для данной операции выделите строку в таблице");
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
