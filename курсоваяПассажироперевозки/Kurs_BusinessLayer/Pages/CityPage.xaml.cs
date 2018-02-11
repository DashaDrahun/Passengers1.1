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
using System.ComponentModel;

namespace Kurs_BusinessLayer.Pages
{
    /// <summary>
    /// Interaction logic for CityPage.xaml
    /// </summary>
    public partial class CityPage : Page, INotifyPropertyChanged
    {
        // СОЗДАНИЕ ДЕЛЕГАТА ДЛЯ ТОГО ЧТОБЫ КОГДА В CityPageVM.cs СРАБОТАЕТ EditCityCommand - в Datagrid обновились строки (Handler())
        public delegate void HelperDeleg();
        public static HelperDeleg newhelperdeleg = null;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        //public static event HelperDeleg myevent = null;

        public void Handler ()
        {
            MessageBox.Show("Сработал делегат!");
            // как статик делегат, сообщенный с методом Handler, меняет dGrid.Columns[1].Header,ведь dGrid - не статическая переменная?
            //Как это происходит без создания экземляра класса CityPage?
            dGrid.Columns[1].Header="BLA-BLA";

        }

        

        public CityPage(CityPageVM page)
        {
            // сработает ли?
            // myevent += Handler;
            newhelperdeleg = new HelperDeleg(Handler);
            InitializeComponent();
            this.DataContext = page;
            //dGrid.ItemsSource = page.Allcities;
       }
        private void dGrid_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;

        }
    }
}