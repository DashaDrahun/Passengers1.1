using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_DataLayer.EFContext;
using Kurs_DataLayer.Entities;
using Kurs_DataLayer.Interfaces;
using System.Data.Entity;
using System.Windows;

namespace Kurs_DataLayer.Repositories
{
    public class TripsRepository : IRepository<Trip>
    {
        EntityContext context;
        public TripsRepository(EntityContext context)
        {
            this.context = context;
        }
        public void Create(Trip t)
        {
            context.Trips.Add(t);
        }

        public void Delete(Trip t)
        {
            var db = context.Trips.Find(t.TripId);
            if (db.Orders.Count > 0)
            {
                if (db.Departure <= DateTime.Now)
                    context.Trips.Remove(db);
                else
                {
                    MessageBox.Show("К рейсу привязаны действующие заказы! Нельзя удалить");
                    return;
                }
            }

            context.Trips.Remove(db);
        }

        public IEnumerable<Trip> Find(Func<Trip, bool> predicate)
        {
            // WTD?? Вообще хз пока с этим
            // Метод Include применяется к запросу указанием имени свойства ассоциации между 
            //запрашиваемым типом (Credit_Contract) и типом(Clients), который требуется загрузить в виде строки
            return context
           .Trips
       .Include(g => g.Route).Include(g => g.Status)
       .Where(predicate)
       .ToList();
        }

        public Trip Get(int id)
        {
            return context.Trips.Find(id);
        }

        public IEnumerable<Trip> GetAll()
        {
            return context.Trips.Include(g => g.Status).Include(g => g.Route)/*.Where(g => g.Departure>DateTime.Today)*/;
        }

        public void Update(Trip t)
        {
            var db = context.Trips.Find(t.TripId);
            db.RouteId = t.RouteId;
            db.StatusId = t.StatusId;
            db.Arrival = t.Arrival;
            db.Departure = t.Departure;
            db.FreeSeetsNumber = t.FreeSeetsNumber;
            db.Price = t.Price;
            context.Entry<Trip>(db).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
