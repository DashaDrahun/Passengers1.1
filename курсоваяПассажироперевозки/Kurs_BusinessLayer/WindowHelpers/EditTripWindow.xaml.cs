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
    /// Interaction logic for EditTripWindow.xaml
    /// </summary>
    public partial class EditTripWindow : Window
    {
        public EditTripWindow(TripViewModel edittrip)
        {
            InitializeComponent();
            dtpDtArr.Text = edittrip.Arrival.ToString();
            dtpDtDep.Text = edittrip.Departure.ToString();
            tbfreeseats.Text = edittrip.FreeSeetsNumber.ToString();
            tbprice.Text = edittrip.Price.ToString();
            cbRoute_Copy.Text = edittrip.Status.ToString();
            EditTripWindowVM viewmodel = new EditTripWindowVM(this, edittrip);
            this.DataContext = viewmodel;
            dtpDtArr.DataContext = viewmodel.trip;
            dtpDtDep.DataContext = viewmodel.trip;


        }
    }
}
