using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kurs_BusinessLayer.Models;
using Kurs_BusinessLayer.ViewModelsForViews;
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.WindowHelpers
{
    /// <summary>
    /// Interaction logic for EditCityWindow.xaml
    /// </summary>
    public partial class EditCityWindow : Window
    {
        public EditCityWindow(CityViewModel editcity)
        {
            InitializeComponent();
            tbName.Text = editcity.Name;
            EditCityWindowVM viewmodel = new EditCityWindowVM(this, editcity);
            this.DataContext = viewmodel;
            tbName.DataContext = viewmodel.city;
        }
    }
}
