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

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    public class EditClientWindowVM:ClientPageVM
    {
        Window window;
        private ClientViewModel client=new ClientViewModel ();
        public EditClientWindowVM(Window window, ClientViewModel editclient):base("NewPasTransfDbConnection")
        {
            this.window = window;
            Client = editclient;
            InitializeCommands();
        }

        public ICommand OkEditClientCommand { get; set; }
        public ICommand CancelEditClientCommand { get; set; }

        public ClientViewModel Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;

            }
        }

        private void InitializeCommands()
        {
            OkEditClientCommand = new RelayCommand(p =>
            {
                // здесь должна быть валидация!!
                if (Client.Name!="" && Client.Family!="" && Client.Patronymic!="")
                {
                    this.UpdateClient(Client);
                    window.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Введите ФИО клиента");
                    return;
                }

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
