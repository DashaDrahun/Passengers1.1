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

namespace Kurs_BusinessLayer.WindowHelpers
{
    /// <summary>
    /// Interaction logic for AddNewOrderWindow.xaml
    /// </summary>
    public partial class AddNewOrderWindow : Window
    {
        public AddNewOrderWindow(ClientViewModel clientfororder)
        {
            InitializeComponent();
            AddNewOrderWindowVM viewmodel = new AddNewOrderWindowVM(this, clientfororder);
            this.DataContext = viewmodel;

        }
    }
}
