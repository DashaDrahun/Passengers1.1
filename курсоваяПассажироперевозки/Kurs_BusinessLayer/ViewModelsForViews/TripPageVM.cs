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
    public class TripPageVM : TripService, INotifyPropertyChanged
    {
        private ObservableCollection<TripViewModel> alltrips;
        private TripViewModel selectedtrip;
        public TripViewModel SelectedTrip
        {
            get { return selectedtrip; }

            set
            {
                selectedtrip = value;
                OnPropertyChanged("SelectedTrip");
            }

        }

        public TripPageVM(string name) : base(name)
        {
            Alltrips = GetAll();
            InitializeCommands();
        }

        public ICommand AddTripCommand { get; set; }
        public ICommand DeleteTripCommand { get; set; }
        public ICommand EditTripCommand { get; set; }

        public ObservableCollection<TripViewModel> Alltrips
        {
            get
            {
                return alltrips;
            }

            set
            {
                alltrips = value;
                OnPropertyChanged("Alltrips");
            }
        }

        private void InitializeCommands()
        {

            EditTripCommand = new RelayCommand(p =>
            {
                if (selectedtrip != null)
                {
                    EditTripWindow window = new EditTripWindow(selectedtrip);
                    if (window.ShowDialog() == true)
                    {
                        //Alltrips = this.GetAll();

                    }
                    else
                    {
                        Alltrips = this.GetAll();
                    }
                }
            });

            AddTripCommand = new RelayCommand(p =>
            {
                AddNewTripWindow window = new AddNewTripWindow();
                if (window.ShowDialog() == true)
                {
                    Alltrips = this.GetAll();

                }

            });

            DeleteTripCommand = new RelayCommand(p =>
            {
                if (selectedtrip != null)
                {
                    //if (SelectedTrip.Orders.Count > 0)
                    //{
                    //    MessageBox.Show("У рейса есть заказы! Не подлежит изменению");
                    //    return;
                    //}
                    var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DeleteTrip(selectedtrip);
                        Alltrips = this.GetAll();
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
