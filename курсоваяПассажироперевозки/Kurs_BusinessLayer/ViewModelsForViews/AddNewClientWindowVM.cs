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
    public class AddNewClientWindowVM:ClientPageVM
    {
        Window window;
        public ClientViewModel client=new ClientViewModel();

        public AddNewClientWindowVM(Window window) : base("NewPasTransfDbConnection")
        {
            this.window = window;
            InitializeCommands();
        }

        public ICommand OkAddClientCommand { get; set; }
        public ICommand CancelAddClientCommand { get; set; }

        private void InitializeCommands()
        {
            OkAddClientCommand = new RelayCommand(p =>
            {
                if (client.Name != "" && client.Family != "" && client.Patronymic != "" && client.Tel_Mobile!="" && client.DateBirth!=null)
                {
                    this.CreateClient(client);

                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }
                window.DialogResult = true;
            }
            );

            CancelAddClientCommand = new RelayCommand(p =>
            {
                window.DialogResult = false;
            }
            );
        }
    }
}
