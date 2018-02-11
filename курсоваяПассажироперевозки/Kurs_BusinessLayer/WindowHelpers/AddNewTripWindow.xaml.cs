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
    /// Interaction logic for AddNewTripWindow.xaml
    /// </summary>
    public partial class AddNewTripWindow : Window
    {
        public AddNewTripWindow()
        {
            InitializeComponent();
            AddNewTripWindowVM viewmodel = new AddNewTripWindowVM(this);
            this.DataContext = viewmodel;
            dtpDtDep.DataContext = viewmodel.trip;
            dtpDtArr.DataContext = viewmodel.trip;
        }
    }
}
