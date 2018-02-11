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
    /// Interaction logic for EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public EditClientWindow(ClientViewModel editclient)
        {
            InitializeComponent();
            tbFamily.Text = editclient.Family;
            tbName.Text = editclient.Name;
            tbPatronym.Text = editclient.Patronymic;
            tbPasspNum.Text = editclient.Tel_Mobile;
            tbAddrOfRes.Text = editclient.VKProfile;
            tbAddrReg.Text = editclient.Email;
            dpDtBirth.Text = editclient.DateBirth.ToString();
            EditClientWindowVM viewmodel = new EditClientWindowVM(this, editclient);
            this.DataContext = viewmodel;
            tbFamily.DataContext = viewmodel.Client;
            tbName.DataContext = viewmodel.Client;
            tbPatronym.DataContext = viewmodel.Client;
            tbPasspNum.DataContext = viewmodel.Client;
            tbAddrOfRes.DataContext = viewmodel.Client;
            tbAddrReg.DataContext = viewmodel.Client;
            dpDtBirth.DataContext = viewmodel.Client;

        }
    }
}
