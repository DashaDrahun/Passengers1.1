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
    class StatusesRepository : IRepository<Status>
    {
        EntityContext context;
        public StatusesRepository(EntityContext context)
        {
            this.context = context;
        }
        public void Create(Status t)
        {
            context.Statuses.Add(t);
        }

        public void Delete(Status t)
        {
            context.Statuses.Remove(t);
        }

        public IEnumerable<Status> Find(Func<Status, bool> predicate)
        {
            // WTD?? Вообще хз пока с этим
            // Метод Include применяется к запросу указанием имени свойства ассоциации между 
            //запрашиваемым типом (Credit_Contract) и типом(Clients), который требуется загрузить в виде строки
            return context
           .Statuses
       .Include(g => g.Orders)
       .Where(predicate)
       .ToList();
        }

        public Status Get(int id)
        {
            return context.Statuses.Find(id);
        }

        public IEnumerable<Status> GetAll()
        {
            return context.Statuses;
        }

        public void Update(Status t)
        {
            // WTD?? Вообще хз пока с этим
            // !! Кстати, в кредитах у меня тут другой код
            context.Entry<Status>(t).State = EntityState.Modified;
        }
    }
}
