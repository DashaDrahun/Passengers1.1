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
    public class TripService : ITripService
    {
        IUnitOfWork database;
        public TripService(string name)
        {
            database = new EFUnitOfWork(name);
        }

        public void CreateTrip(TripViewModel trip_vm)
        {
            Trip trip = new Trip
            {
                RouteId = trip_vm.Route.RouteId,
                StatusId = trip_vm.Status.StatusId,
                Arrival = trip_vm.Arrival,
                Departure = trip_vm.Departure,
                FreeSeetsNumber=trip_vm.FreeSeetsNumber,
                Price=trip_vm.Price
            };
            database.Trips.Create(trip);
            database.Save();
        }

        public void DeleteTrip(TripViewModel trip_vm)
        {
            Trip trip = new Trip
            {
                TripId=trip_vm.TripId,
                RouteId = trip_vm.Route.RouteId,
                StatusId = trip_vm.Status.StatusId,
                Arrival = trip_vm.Arrival,
                Departure = trip_vm.Departure,
                FreeSeetsNumber = trip_vm.FreeSeetsNumber,
                Price = trip_vm.Price
            };
            database.Trips.Delete(trip);
            database.Save();
        }

        public TripViewModel Get(int id)
        {
            var trip = database.Trips.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Trip, TripViewModel>());
            var restr = Mapper.Map<TripViewModel>(trip);
            return restr;
        }

        public ObservableCollection<TripViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Route, RouteViewModel>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<Status, StatusViewModel>();
            });
            var mapper = config.CreateMapper();
            // Отображение List<City> на ObservableCollection<CityViewModel>
            var trips = mapper.Map<ObservableCollection<TripViewModel>>(database.Trips.GetAll());
            return trips;
        }


        public void ShowAllOrders(int tripId, ObservableCollection<OrderViewModel> orders)
        {
            throw new NotImplementedException();
        }


        public void UpdateTrip(TripViewModel trip_vm)
        {
            Trip trip = new Trip
            {
                TripId = trip_vm.TripId,
                RouteId = trip_vm.Route.RouteId,
                StatusId = trip_vm.Status.StatusId,
                Arrival = trip_vm.Arrival,
                Departure = trip_vm.Departure,
                FreeSeetsNumber = trip_vm.FreeSeetsNumber,
                Price = trip_vm.Price
            };
            database.Trips.Update(trip);
            database.Save();
        }

        public ObservableCollection<RouteViewModel> GetAllRoutesForTrip()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Route, RouteViewModel>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<City, CityViewModel>();
            });
            var mapper = config.CreateMapper();
            var routes = mapper.Map<ObservableCollection<RouteViewModel>>(database.Routes.GetAll());
            return routes;
        }

        public ObservableCollection<StatusViewModel> GetAllStatusesForTrip()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Status, StatusViewModel>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
            });
            var mapper = config.CreateMapper();
            var statuses = mapper.Map<ObservableCollection<StatusViewModel>>(database.Statuses.GetAll());
            return statuses;
        }
    }
}
