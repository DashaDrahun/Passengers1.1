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
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.ViewModelsForViews
{
    public class EditCityWindowVM: CityService
    {
        Window window;
        public CityViewModel city;
        string oldcityname;


        public EditCityWindowVM(Window window, CityViewModel editcity) : base("NewPasTransfDbConnection")
        {
            this.window = window;
            city = editcity;
            oldcityname = editcity.Name;
            InitializeCommands();
        }

        public ICommand OkAddCityCommand { get; set; }
        public ICommand CancelAddCityCommand { get; set; }

        private void InitializeCommands()
        {
            OkAddCityCommand = new RelayCommand(p =>
            {
                if (Regex.IsMatch(city.Name, @"^[а-яА-Я]+$"))
                {
                    this.UpdateCity(city);
                    window.DialogResult = true;
                }
                else
                {
                    city.Name = oldcityname;
                    MessageBox.Show("Присутствуют недопустимые для ввода символы. Повторите ввод");
                    window.DialogResult = false;
                }        
            }
            );

            CancelAddCityCommand = new RelayCommand(p =>
            {
                city.Name = oldcityname;
                window.DialogResult = false;
            }
            );
        }
    }
}
