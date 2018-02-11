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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kurs_BusinessLayer.ViewModelsForViews;

namespace Kurs_BusinessLayer.Pages
{
    /// <summary>
    /// Interaction logic for TripPage.xaml
    /// </summary>
    public partial class TripPage : Page
    {
        public TripPage(TripPageVM page)
        {
            InitializeComponent();
            this.DataContext = page;
            dGrid.ItemsSource = page.Alltrips;
        }

        private void dGrid_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;

        }
    }
}
