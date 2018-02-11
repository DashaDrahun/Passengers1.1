using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_DataLayer.EFContext;
using Kurs_DataLayer.Entities;
using Kurs_DataLayer.Interfaces;
using System.Data.Entity;

namespace Kurs_DataLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<City> Cities { get; }
        IRepository<Client> Clients { get; }
        IRepository<Order> Orders { get; }
        IRepository<Route> Routes { get; }
        IRepository<Status> Statuses { get; }
        IRepository<Trip> Trips { get; }
        void Save();
    }
}
