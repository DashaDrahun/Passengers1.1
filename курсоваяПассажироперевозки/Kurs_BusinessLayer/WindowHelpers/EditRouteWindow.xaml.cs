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
using System.Windows.Controls.Primitives;

namespace Kurs_BusinessLayer.WindowHelpers
{
    /// <summary>
    /// Interaction logic for EditRouteWindow.xaml
    /// </summary>
    public partial class EditRouteWindow : Window
    {
        public EditRouteWindow(RouteViewModel editroute)
        {
            InitializeComponent();
            tbKm.Text = editroute.Kilometres.ToString();
            EditRouteWindowVM viewmodel = new EditRouteWindowVM(this, editroute);
            this.DataContext = viewmodel;
        }
    }
}
