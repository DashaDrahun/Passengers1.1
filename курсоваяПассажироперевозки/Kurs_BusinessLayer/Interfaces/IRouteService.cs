using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kurs_BusinessLayer.Models;

namespace Kurs_BusinessLayer.Interfaces
{
    public interface IRouteService
    {
        ObservableCollection<RouteViewModel> GetAll();
        RouteViewModel Get(int id);
        void CreateRoute(RouteViewModel route);
        void DeleteRoute(RouteViewModel route);
        void UpdateRoute(RouteViewModel route);
        // правильно ли так делать?
        // используется для подгружения из бд городов для формирования маршрута
        ObservableCollection<CityViewModel> GetAllCitiesForRoute();


    }
}
