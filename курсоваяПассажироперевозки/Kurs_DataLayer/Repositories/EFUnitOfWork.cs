using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_DataLayer.Entities;
using Kurs_DataLayer.Interfaces;
using Kurs_DataLayer.EFContext;


namespace Kurs_DataLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        EntityContext context;
        CitiesRepository citiesRepository;
        ClientsRepository clientsRepository;
        OrdersRepository ordersRepository;
        RoutesRepository routesRepository;
        StatusesRepository statusesRepository;
        TripsRepository tripsRepository;

        public EFUnitOfWork(string name)
        {
            context = new EntityContext(name);
        }

        public IRepository<City> Cities
        {
            get
            {
                if (citiesRepository == null)
                    citiesRepository = new CitiesRepository(context);
                return citiesRepository;
            }

        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientsRepository == null)
                    clientsRepository = new ClientsRepository(context);
                return clientsRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (ordersRepository == null)
                    ordersRepository = new OrdersRepository(context);
                return ordersRepository;
            }
        }

        public IRepository<Route> Routes
        {
            get
            {
                if (routesRepository == null)
                    routesRepository = new RoutesRepository(context);
                return routesRepository;
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                if (statusesRepository == null)
                    statusesRepository = new StatusesRepository(context);
                return statusesRepository;
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                if (tripsRepository == null)
                    tripsRepository = new TripsRepository(context);
                return tripsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EFUnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
