using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kurs_BusinessLayer.Models;

namespace Kurs_BusinessLayer.Interfaces
{
    public interface IClientService
    {
        ObservableCollection<ClientViewModel> GetAll();
        ClientViewModel Get(int id);
        //void AddOrder(int clientId, OrderViewModel order);
        void DeleteOrder(int clientId, int orderId);
        void ModifyOrder(int clientId, int orderId);
        void ShowOrder (int clientId, int orderId);
        void ShowAllOrders(int clientId, ObservableCollection<OrderViewModel> orders);
        void CreateClient(ClientViewModel client);
        void DeleteClient(ClientViewModel client);
        void UpdateClient(ClientViewModel client);
        void CreateOrder(OrderViewModel order);
        int GetFreeSeatNumberForOrder(TripViewModel trip_vm);
    }
}
