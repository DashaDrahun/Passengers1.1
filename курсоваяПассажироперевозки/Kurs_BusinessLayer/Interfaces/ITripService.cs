using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kurs_BusinessLayer.Models;

namespace Kurs_BusinessLayer.Interfaces
{
    public interface ITripService
    {
        ObservableCollection<TripViewModel> GetAll();
        TripViewModel Get(int id);
        void ShowAllOrders(int tripId, ObservableCollection<OrderViewModel> orders);
        void CreateTrip(TripViewModel trip);
        void DeleteTrip(TripViewModel trip);
        void UpdateTrip(TripViewModel trip);
        ObservableCollection<RouteViewModel> GetAllRoutesForTrip();
        ObservableCollection<StatusViewModel> GetAllStatusesForTrip();
    }
    
}
