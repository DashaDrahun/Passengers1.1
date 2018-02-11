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
using Kurs_BusinessLayer.ViewModelsForViews;

namespace Kurs_BusinessLayer.WindowHelpers
{
    /// <summary>
    /// Interaction logic for AddNewCityWindow.xaml
    /// </summary>
    public partial class AddNewCityWindow : Window
    {
        public AddNewCityWindow()
        {
            InitializeComponent();
            AddNewCityWindowVM viewmodel = new AddNewCityWindowVM(this);
            this.DataContext = viewmodel;
            tbName.DataContext = viewmodel.city;


        }
    }
}
