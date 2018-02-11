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
    /// Interaction logic for AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        public AddNewClientWindow()
        {
            InitializeComponent();
            AddNewClientWindowVM viewmodel = new AddNewClientWindowVM(this);
            this.DataContext = viewmodel;
            tbFamily.DataContext = viewmodel.client;
            tbName.DataContext = viewmodel.client;
            tbPatronym.DataContext = viewmodel.client;
            tbPasspNum.DataContext = viewmodel.client;
            tbAddrOfRes.DataContext = viewmodel.client;
            tbAddrReg.DataContext = viewmodel.client;
            dpDtBirth.DataContext = viewmodel.client;
        }
    }
}
