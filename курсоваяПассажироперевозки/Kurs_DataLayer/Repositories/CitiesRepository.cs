using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_DataLayer.EFContext;
using Kurs_DataLayer.Entities;
using Kurs_DataLayer.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Kurs_DataLayer.Repositories
{
    public class CitiesRepository : IRepository<City>
    {
        EntityContext context;
        public CitiesRepository(EntityContext context)
        {
            this.context = context;
        }
        public void Create(City t)
        {
            context.Cities.Add(t);
        }

        public void Delete(City t)
        {
            // NB! при наличии одного соединения (как у меня) а не открытия отдельного соединения на каждый запрос к бд
            //(например смотри ниже)
            //using (var context = new MyDataContext())
            //{
            //    // Note: Attatch to the entity:
            //    context.MyTableEntity.Attach(EntityToRemove);

            //    context.MyTableEntity.Remove(EntityToRemove);
            //    var nrOfObjectsChanged = context.SaveChanges();
            //}
            //НЕЛЬЗЯ передать сущность для удаления как параметр функции (public void Delete(City t))
            // и сделать что-то вроде context.Cities.Remove(t) - будет иксапшн, что не может найти данный объект в контексте,
            // (хотя есть с такими же полями). Просто он его так не ищет для удаления. А если мы захотим сделать Attach этого объекта,
            // то тоже будет иксепшн - напишет, что в контексте уже существует объект с таким же первичным ключом (естественно существует)
            // Объяснение, почему код ниже работает - мы через SQL запрос берем действительно то, что находится в БД
            //но почему он не ищет для удаления City t - до конца непонятно
            var db = context.Cities.Where(u => u.CityId.Equals(t.CityId)).FirstOrDefault();
            context.Cities.Remove(db);
        }

        public IEnumerable<City> Find(Func<City, bool> predicate)
        {
            return context
           .Cities
       .Where(predicate)
       .ToList();
        }

        public City Get(int id)
        {
            return context.Cities.Find(id);
        }

        public IEnumerable<City> GetAll()
        {
            //using (var ctx = new EntityContext("NewPasTransfDbConnection"))
            //{
            //    context=ctx; return context.Cities.OrderBy(g => g.Name);  
            //}
            return context.Cities.OrderBy(g => g.Name);
            //var res = context.Database.SqlQuery<City>("Select * From Cities");
            //return res;


        }

        public void Update(City t)
        {
            //using (var ctx = new EntityContext("NewPasTransfDbConnection"))
            //{
            //    //var db = ctx.Cities.Where(u => u.CityId.Equals(t.CityId)).FirstOrDefault();
            //    (ctx.Cities.Where(u => u.CityId.Equals(t.CityId)).FirstOrDefault()).Name = t.Name;
            //   // ctx.Cities.Attach(db);
            //    ctx.Entry(ctx.Cities.Where(u => u.CityId.Equals(t.CityId)).FirstOrDefault()).Property(c => c.Name).IsModified = true;
            //    ctx.Entry<City>(ctx.Cities.Where(u => u.CityId.Equals(t.CityId)).FirstOrDefault()).State = EntityState.Modified;
            //    ctx.SaveChanges();
            //    context.Cities = ctx.Cities;
            //    context.SaveChanges();
            //}
            var db = context.Cities.Where(u => u.CityId.Equals(t.CityId)).FirstOrDefault();
            db.Name = t.Name;
            //context.Entry(db).Reload();
            context.Cities.Attach(db);
            context.Entry(db).Property(c => c.Name).IsModified = true;
            context.Entry<City>(db).State = EntityState.Modified;
            //context.Entry(db).Reload();
            context.SaveChanges();
        }
    }
}
