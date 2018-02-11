using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_BusinessLayer.Interfaces;
using Kurs_BusinessLayer.Models;
using Kurs_DataLayer.Entities;
using Kurs_DataLayer.Interfaces;
using Kurs_DataLayer.Repositories;
using AutoMapper;

namespace Kurs_BusinessLayer.Services
{
    public class ClientService : IClientService
    {
        IUnitOfWork database;
        public ClientService(string name)
        {
            database = new EFUnitOfWork(name);
        }

        public void CreateClient(ClientViewModel client_vm)
        {
            // Конфигурирование AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientViewModel, Client>());
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            var client_m = mapper.Map<Client>(client_vm);
            database.Clients.Create(client_m);
            database.Save();
        }

        public int GetFreeSeatNumberForOrder(TripViewModel trip_vm)
        {
            return database.Trips.Get(trip_vm.TripId).FreeSeetsNumber;
        }

        public void DeleteClient(ClientViewModel client_vm)
        {
            // Конфигурирование AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientViewModel, Client>());
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            // ?? сработает ли так (параметр не ClientViewModel, а айдишник int)
            var client_m = mapper.Map<Client>(client_vm);
            database.Clients.Delete(client_m);
            database.Save();
        }

        public void DeleteOrder(int clientId, int orderId)
        {
            var client = database.Clients.Get(clientId);
            var order = database.Orders.Get(orderId);
            client.Orders.Remove(order);
        }

        public ClientViewModel Get(int id)
        {
            var client = database.Clients.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientViewModel>());
            var rescl = Mapper.Map<ClientViewModel>(client);
            return rescl;
        }

        public ObservableCollection<ClientViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, ClientViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
                
            });
            var mapper = config.CreateMapper();
            // Отображение List<City> на ObservableCollection<CityViewModel>
            var clients = mapper.Map<ObservableCollection<ClientViewModel>>(database.Clients.GetAll());
            return clients;
        }
        public void ModifyOrder(int clientId, int orderId)
        {
            throw new NotImplementedException();
        }

        public void ShowAllOrders(int clientId, ObservableCollection<OrderViewModel> orders)
        {
            throw new NotImplementedException();
        }

        public void ShowOrder(int clientId, int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(ClientViewModel client_vm)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientViewModel, Client>());
            var mapper = config.CreateMapper();
            var client_m = mapper.Map<Client>(client_vm);
            database.Clients.Update(client_m);
            database.Save();
        }

        //public ObservableCollection<StatusViewModel> GetAllStatusesForTrip()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Status, StatusViewModel>();
        //        cfg.CreateMap<Trip, TripViewModel>();
        //        cfg.CreateMap<Order, OrderViewModel>();
        //    });
        //    var mapper = config.CreateMapper();
        //    var statuses = mapper.Map<ObservableCollection<StatusViewModel>>(database.Statuses.GetAll());
        //    return statuses;
        //}

        public ObservableCollection<TripViewModel> GetAvaliableTripsForClient()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Route, RouteViewModel>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<Status, StatusViewModel>();
            });
            var mapper = config.CreateMapper();
            var trips = mapper.Map<ObservableCollection<TripViewModel>>(database.Trips.Find(p=> { return p.Departure >= DateTime.Now; }));
            //var trips = mapper.Map<ObservableCollection<TripViewModel>>(database.Trips.Find(p => { return p.StatusId == 1 || p.Departure >= DateTime.Now; }));
            return trips;
        }

        public void CreateOrder(OrderViewModel order_vm)
        {
            IEnumerable<Status> statuses= database.Statuses.GetAll();
            List<Status> list = statuses.ToList<Status>();
            Order neworder = new Order();
            neworder.ClientId = order_vm.Client.ClientId;
            neworder.TripId = order_vm.Trip.TripId;
            neworder.StatusId = list[0].StatusId;
            neworder.SeatNumber = order_vm.SeatNumber;

            database.Orders.Create(neworder);
            database.Save();

            //}
            //// Конфигурирование AutoMapper
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ClientViewModel, Client>();
            //    cfg.CreateMap<TripViewModel, Trip>();
            //    cfg.CreateMap<OrderViewModel, Order>();
            //    cfg.CreateMap<StatusViewModel, Status>();
            //});
            //var mapper = config.CreateMapper();
            //var order_m = mapper.Map<Order>(order_vm);
            //database.Orders.Create(order_m);
            //database.Save();
        }
    }
}
