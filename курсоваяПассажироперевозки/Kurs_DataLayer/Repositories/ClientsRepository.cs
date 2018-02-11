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
    public class ClientsRepository : IRepository<Client>
    {
        EntityContext context;
        public ClientsRepository(EntityContext context)
        {
            this.context = context;
        }
        public void Create(Client t)
        {
            context.Clients.Add(t);
        }

        public void Delete(Client t)
        {
            var db = context.Clients.Where(u => u.ClientId.Equals(t.ClientId)).FirstOrDefault();
            context.Clients.Remove(db);
        }

        public IEnumerable<Client> Find(Func<Client, bool> predicate)
        {
            // WTD?? Вообще хз пока с этим
            // Метод Include применяется к запросу указанием имени свойства ассоциации между 
            //запрашиваемым типом (Credit_Contract) и типом(Clients), который требуется загрузить в виде строки
            return context
           .Clients
       .Include(g => g.Orders)
       .Where(predicate)
       .ToList();
        }

        public Client Get(int id)
        {
            return context.Clients.Find(id);
        }

        public IEnumerable<Client> GetAll()
        {
            // WTD?? Вообще хз пока с этим
            return context.Clients.Include(g => g.Orders).OrderBy(g => g.Family);
        }

        public void Update(Client t)
        {
            var db = context.Clients.Where(u => u.ClientId.Equals(t.ClientId)).FirstOrDefault();
            db.Family = t.Family;
            db.Name = t.Name;
            db.Patronymic = t.Patronymic;
            db.Tel_Mobile = t.Tel_Mobile;
            db.Email = t.Email;
            db.DateBirth = t.DateBirth;
            db.VKProfile = t.VKProfile;
            context.Entry<Client>(db).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
