using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kurs_BusinessLayer.Models;

namespace Kurs_BusinessLayer.Interfaces
{
    public interface IStatusService
    {
        ObservableCollection<StatusViewModel> GetAll();
        StatusViewModel Get(int id);
        void AttachOrderToStatus(int statusId, OrderViewModel order);
        void AttachTripToStatus(int statusId, TripViewModel trip);
        void DetachOrderFromStatus(int statusId, int orderId);
        void DetachTripFromStatus(int statusId, int tripId);
        void CreateStatus(StatusViewModel status);
        void DeleteStatus(int statusId);
        void UpdateStatus(StatusViewModel status);
    }
}
