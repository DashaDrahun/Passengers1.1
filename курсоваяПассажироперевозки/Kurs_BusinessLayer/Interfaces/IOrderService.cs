using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kurs_BusinessLayer.Models;

namespace Kurs_BusinessLayer.Interfaces
{
    // ??? БУДЕТ ЛИ ТАКАЯ ФУНКЦИОНАЛЬНОСТЬ У Order?? (или вообще не будет никакой функциональности?)
    public interface IOrderService
    {
        ObservableCollection<OrderViewModel> GetAll();
        OrderViewModel Get(int id);
        void CreateOrder(OrderViewModel order);
        void DeleteOrder(int orderId);
        void UpdateOrder(OrderViewModel order);
    }
}
