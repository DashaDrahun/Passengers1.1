using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace Kurs_BusinessLayer.Models
{
    public class CityViewModel : BaseVM
    {
        private int cityId;
        public int CityId
        {
            get
            {
                return cityId;
            }
            set
            {
                cityId = value;
                OnPropertyChanged(nameof(CityId));
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }




            //public ObservableCollection<RouteViewModel> RoutesDep { get; set; }
            //public ObservableCollection<RouteViewModel> RoutesArr { get; set; }


        }
    }
}

