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
    public class OrderService : IOrderService
    {
        IUnitOfWork database;
        public OrderService(string name)
        {
            database = new EFUnitOfWork(name);
        }
        public void CreateOrder(OrderViewModel order_vm)
        {
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, Order>());
            // Отображение объекта CityViewModel на City
            var order_m = Mapper.Map<Order>(order_vm);
            database.Orders.Create(order_m);
        }

        public void DeleteOrder(int orderId)
        {
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, Order>());
            // Отображение объекта CityViewModel на City
            // ?? сработает ли так (параметр не OrderViewModel, а айдишник int)
            var order_m = Mapper.Map<Order>(orderId);
            database.Orders.Delete(order_m);
        }



        public OrderViewModel Get(int id)
        {
            var order = database.Orders.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderViewModel>());
            var resor = Mapper.Map<OrderViewModel>(order);
            return resor;
        }

        public ObservableCollection<OrderViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, ClientViewModel>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<Status, StatusViewModel>();
                cfg.CreateMap<Route, RouteViewModel>();
                cfg.CreateMap<City, CityViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
            });
            var mapper = config.CreateMapper();
            //var resultm = database.Orders.GetAll();
            //ObservableCollection<OrderViewModel> resultvm = new ObservableCollection<OrderViewModel>();
            //foreach (var a in resultm)
            //{
            //    resultvm.Add(new OrderViewModel { OrderId = a.OrderId, SeatNumber = a.SeatNumber });
            //}
            var orders = mapper.Map<ObservableCollection<OrderViewModel>>(database.Orders.GetAll());
            return orders;
        }

        public void UpdateOrder(OrderViewModel order_vm)
        {
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, Order>());
            // Отображение объекта CityViewModel на City
            var order_m = Mapper.Map<Order>(order_vm);
            database.Orders.Update(order_m);
        }
    }
}
