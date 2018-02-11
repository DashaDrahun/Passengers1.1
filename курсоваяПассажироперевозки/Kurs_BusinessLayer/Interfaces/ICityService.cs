using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kurs_BusinessLayer.Models;

namespace Kurs_BusinessLayer.Interfaces
{
    public interface ICityService
    {
        ObservableCollection<CityViewModel> GetAll();
        CityViewModel Get(int id);
        void CreateCity(CityViewModel city);
        void DeleteCity(CityViewModel city);
        void UpdateCity(CityViewModel city);
    }
}
