using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Kurs_BusinessLayer.InterfacesForViews;
using Kurs_BusinessLayer.Helpers;
using Kurs_BusinessLayer.Pages;

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    public class MainWindowVM:IMainWindowVM,INotifyPropertyChanged
    {
        #region Fields

        private Page _currentPage;


        #endregion


        #region Constructors

        public MainWindowVM()
        {

            InitializeCommands();
        }



        #endregion

        #region Properties

        public Page CurrentPage
        {
            get { return _currentPage == null ? new HomePage() : _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public ICommand GoToCityPageCommand { get; set; }
        public ICommand GoToRoutePageCommand { get; set; }
        public ICommand GoToTripPageCommand { get; set; }
        public ICommand GoToClientPageCommand { get; set; }
        public ICommand GoToOrderPageCommand { get; set; }


        #endregion

        #region Methods

        private void InitializeCommands()
        {
            GoToCityPageCommand = new RelayCommand(p => CurrentPage = new CityPage(new CityPageVM("NewPasTransfDbConnection")));
            GoToRoutePageCommand = new RelayCommand(p => CurrentPage = new RoutePage(new RoutePageVM("NewPasTransfDbConnection")));
            GoToTripPageCommand = new RelayCommand(p => CurrentPage = new TripPage(new TripPageVM("NewPasTransfDbConnection")));
            GoToClientPageCommand = new RelayCommand(p=> CurrentPage=new ClientPage(new ClientPageVM("NewPasTransfDbConnection")));
            GoToOrderPageCommand = new RelayCommand(p => CurrentPage = new OrderPage(new OrderPageVM("NewPasTransfDbConnection")));
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

