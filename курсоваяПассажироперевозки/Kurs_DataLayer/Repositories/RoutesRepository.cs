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
    public class RoutesRepository : IRepository<Route>
    {
        EntityContext context;
        public RoutesRepository(EntityContext context)
        {
            this.context = context;
        }
        public void Create(Route t)
        {
            //var db1 = context.Cities.Where(u => u.CityId.Equals(t.CityDepart.CityId)).FirstOrDefault();
            //db1.RoutesDep.Add(t);
            ////context.Entry<City>(db1).State = EntityState.Modified;
            //var db2 = context.Cities.Where(u => u.CityId.Equals(t.CityArr.CityId)).FirstOrDefault();
            //db2.RoutesArr.Add(t);
            ////context.Entry<City>(db2).State = EntityState.Modified;
            ////context.Routes.Add(t);
            context.Routes.Add(t);
            context.SaveChanges();
        }

        public void Delete(Route t)
        {
            var db = context.Routes.Where(u => u.RouteId.Equals(t.RouteId)).FirstOrDefault();
            context.Routes.Remove(db);
        }

        public IEnumerable<Route> Find(Func<Route, bool> predicate)
        {
            // WTD?? Вообще хз пока с этим
            // Метод Include применяется к запросу указанием имени свойства ассоциации между 
            //запрашиваемым типом (Credit_Contract) и типом(Clients), который требуется загрузить в виде строки
            return context
           .Routes
       .Include(g => g.Trips)
       .Where(predicate)
       .ToList();
        }

        public Route Get(int id)
        {
            return context.Routes.Find(id);
        }

        public IEnumerable<Route> GetAll()
        {
            return context.Routes.Include(g => g.CityArr).Include(g=>g.CityDepart).OrderBy(c => c.CityDepart.Name);
        }

        public void Update(Route t)
        {
            // WTD?? Вообще хз пока с этим
            // !! Кстати, в кредитах у меня тут другой код
            //context.Entry<Route>(t).State = EntityState.Modified;
            var db = context.Routes.Find(t.RouteId);
            //var db = context.Routes.Where(u => u.RouteId.Equals(t.RouteId)).FirstOrDefault();
            //db.CityArr = context.Cities.Where(u => u.CityId.Equals(t.CityArrId)).FirstOrDefault();
            db.CityArrId = t.CityArrId;
            //db.CityDepart = context.Cities.Where(u => u.CityId.Equals(t.CityDepartId)).FirstOrDefault();
            db.CityDepartId = t.CityDepartId;
            db.Kilometres = t.Kilometres;
            //db.RouteId = t.RouteId;
            //db.Trips = t.Trips;
            context.Entry<Route>(db).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
