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
    public class ClientPageVM:ClientService, INotifyPropertyChanged
    {
        private ObservableCollection<ClientViewModel> allclients;
        private ClientViewModel selectedclient;
        public ClientViewModel SelectedClient
        {
            get { return selectedclient; }

            set
            {
                selectedclient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }

        }

        public ClientPageVM(string name) : base(name)
        {
            Allclients = this.GetAll();
            InitializeCommands();
        }

        public ICommand AddClientCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }
        public ICommand EditClientCommand { get; set; }
        public ICommand AddOrderCommand { get; set; }

        public ObservableCollection<ClientViewModel> Allclients
        {
            get
            {
                return allclients;
            }

            set
            {
                allclients = value;
                OnPropertyChanged(nameof(Allclients));
            }
        }

        private void InitializeCommands()
        {

            EditClientCommand = new RelayCommand(p =>
            {
                if (selectedclient != null)
                {
                    EditClientWindow window = new EditClientWindow(selectedclient);
                    OnPropertyChanged(nameof(Allclients));
                    if (window.ShowDialog() == true)
                    {
                        OnPropertyChanged(nameof(Allclients));
                        //Allclients = this.GetAll();
                    }
                    else
                    {
                        Allclients = this.GetAll();
                    }
                }
            });

            AddClientCommand = new RelayCommand(p =>
            {
                AddNewClientWindow window = new AddNewClientWindow();
                if (window.ShowDialog() == true)
                {
                    Allclients = this.GetAll();

                }

            });

            DeleteClientCommand = new RelayCommand(p =>
            {
                if (selectedclient != null)
                {
                    var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DeleteClient(selectedclient);
                        Allclients = this.GetAll();
                    }
                }
            });

            AddOrderCommand = new RelayCommand(p =>
            {
                if (selectedclient != null)
                {
                    AddNewOrderWindow window = new AddNewOrderWindow(selectedclient);
                    if (window.ShowDialog() == true)
                    {
                        Allclients = this.GetAll();

                    }
                }
               else MessageBox.Show("Выберите клиента!");
            }            
            );
            
        
        }



        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

