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
    public class OrderPageVM:OrderService, INotifyPropertyChanged
    {
        public ObservableCollection<OrderViewModel> allorders;

        public OrderPageVM(string name):base(name)
        {
            allorders = this.GetAll();
            InitializeCommands();
        }


        private void InitializeCommands()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
