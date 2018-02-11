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
    public class StatusService:IStatusService
    {
        IUnitOfWork database;
        public StatusService(string name)
        {
            database = new EFUnitOfWork(name);
        }

        public void AttachOrderToStatus(int statusId, OrderViewModel order)
        {
            var status = database.Statuses.Get(statusId);
            Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, Order>());
            var ord = Mapper.Map<Order>(order);
            status.Orders.Add(ord);
        }

        public void AttachTripToStatus(int statusId, TripViewModel trip)
        {
            var status = database.Statuses.Get(statusId);
            Mapper.Initialize(cfg => cfg.CreateMap<TripViewModel, Trip>());
            var tr = Mapper.Map<Trip>(trip);
            status.Trips.Add(tr);
        }

        public void CreateStatus(StatusViewModel status_vm)
        {
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<StatusViewModel, Status>());
            var status_m = Mapper.Map<Status>(status_vm);
            database.Statuses.Create(status_m);
        }

        public void DeleteStatus(int statusId)
        {
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<StatusViewModel, Status>());
            // ?? сработает ли так (параметр не StatusViewModel, а айдишник int)
            var status_m = Mapper.Map<Status>(statusId);
            database.Statuses.Delete(status_m);
        }

        public void DetachOrderFromStatus(int statusId, int orderId)
        {
            var status = database.Statuses.Get(statusId);
            var order = database.Orders.Get(orderId);
            status.Orders.Remove(order);
        }

        public void DetachTripFromStatus(int statusId, int tripId)
        {
            var status = database.Statuses.Get(statusId);
            var trip = database.Trips.Get(tripId);
            status.Trips.Remove(trip);
        }

        public StatusViewModel Get(int id)
        {
            var status = database.Statuses.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Status, StatusViewModel>());
            var resStatus = Mapper.Map<StatusViewModel>(status);
            return resStatus;
        }

        public ObservableCollection<StatusViewModel> GetAll()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Status, StatusViewModel>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();

            });
            var statuses = Mapper.Map<ObservableCollection<StatusViewModel>>(database.Cities.GetAll());
            return statuses;
        }

        public void UpdateStatus(StatusViewModel status_vm)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<StatusViewModel, Status>());
            var status_m = Mapper.Map<Status>(status_vm);
            database.Statuses.Update(status_m);
        }
    }
}
