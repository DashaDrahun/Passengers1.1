using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_DataLayer.EFContext;
using Kurs_DataLayer.Entities;
using Kurs_DataLayer.Interfaces;
using System.Data.Entity;

namespace Kurs_DataLayer.Repositories
{
    class OrdersRepository : IRepository<Order>
    {
        EntityContext context;
        public OrdersRepository(EntityContext context)
        {
            this.context = context;
        }
        public void Create(Order t)
        {
            context.Orders.Add(t);
            var a= context.Trips.FirstOrDefault(p => p.TripId == t.TripId);
            a.FreeSeetsNumber -= 1;
            context.SaveChanges();
        }

        public void Delete(Order t)
        {
            context.Orders.Remove(t);
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            // WTD?? Вообще хз пока с этим
            // Метод Include применяется к запросу указанием имени свойства ассоциации между 
            //запрашиваемым типом (Credit_Contract) и типом(Clients), который требуется загрузить в виде строки
            return context
           .Orders
       .Include(g => g.Client)
       .Where(predicate)
       .ToList();
        }

        public Order Get(int id)
        {
            return context.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            // WTD?? Вообще хз пока с этим
            return context.Orders.Include(g => g.Client).Include(g => g.Status).Include(g => g.Trip).Where(g=> g.Trip.Arrival>=DateTime.Now);

        }

        public void Update(Order t)
        {
            // WTD?? Вообще хз пока с этим
            // !! Кстати, в кредитах у меня тут другой код
            context.Entry<Order>(t).State = EntityState.Modified;
        }
    }
}
