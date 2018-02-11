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
using System.Text.RegularExpressions;

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    public class AddNewCityWindowVM:CityService
    {
        Window window;
        public CityViewModel city=new CityViewModel();
        public AddNewCityWindowVM(Window window):base("NewPasTransfDbConnection")
        {
            this.window = window;
            InitializeCommands();
        }

        public ICommand OkAddCityCommand { get; set; }
        public ICommand CancelAddCityCommand { get; set; }

        private void InitializeCommands()
        {

            OkAddCityCommand = new RelayCommand(p =>
            {
                if (city != null)
                {
                    if (Regex.IsMatch(city.Name, @"^[а-яА-Я]+$"))
                    {
                        this.CreateCity(new CityViewModel
                        {
                            Name = city.Name,
                        });
                        window.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Присутствуют недопустимые для ввода символы. Повторите ввод");
                        return;
                    }
                }
            }
            );

            CancelAddCityCommand = new RelayCommand(p =>
            {
                window.DialogResult = false;
            }
            );
        }

    }
}
