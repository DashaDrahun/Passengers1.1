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
    public class RouteService : IRouteService
    {
        IUnitOfWork database;
        public RouteService(string name)
        {
            database = new EFUnitOfWork(name);
        }

        public void CreateRoute(RouteViewModel route_vm)
        {
            // Конфигурирование AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<RouteViewModel, Route>());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RouteViewModel, Route>();
                cfg.CreateMap<TripViewModel, Trip>();
                cfg.CreateMap<CityViewModel, City>();
            });
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            //var route_m = Mapper.Map<Route>(route_vm);
            var route_m = mapper.Map<Route>(route_vm);
            Route route = new Route {
                CityDepartId = route_vm.CityDepart.CityId,
                CityArrId = route_vm.CityArr.CityId,
                Kilometres = route_vm.Kilometres
            };
            database.Routes.Create(route);
            database.Save();
        }

        public void DeleteRoute(RouteViewModel route_vm)
        {
            // Конфигурирование AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<RouteViewModel, Route>());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RouteViewModel, Route>();
                cfg.CreateMap<TripViewModel, Trip>();
                cfg.CreateMap<CityViewModel, City>();
            });
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            //var route_m = Mapper.Map<Route>(route_vm);
            var route_m = mapper.Map<Route>(route_vm);
            database.Routes.Delete(route_m);
            database.Save();
        }


        public RouteViewModel Get(int id)
        {
            var Route = database.Routes.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Route, RouteViewModel>());
            var resr = Mapper.Map<RouteViewModel>(Route);
            return resr;
        }

        public ObservableCollection<RouteViewModel> GetAll()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Route, RouteViewModel>();
            //    cfg.CreateMap<Trip, TripViewModel>();

            //});
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Route, RouteViewModel>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<City, CityViewModel>();
            });
            var mapper = config.CreateMapper();
            // Отображение List<City> на ObservableCollection<CityViewModel>
            var routes = mapper.Map<ObservableCollection<RouteViewModel>>(database.Routes.GetAll());
            return routes;
        }

        public void UpdateRoute(RouteViewModel route_vm)
        {
            // Конфигурирование AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<RouteViewModel, Route>());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RouteViewModel, Route>();
                cfg.CreateMap<TripViewModel, Trip>();
                cfg.CreateMap<CityViewModel, City>();
            });
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            //var route_m = Mapper.Map<Route>(route_vm);
            var route_m = mapper.Map<Route>(route_vm);
            //database.Routes.Update(route_m);
            //database.Save();

            Route route = new Route
            {
                CityDepartId = route_m.CityDepart.CityId,
                CityArrId = route_m.CityArr.CityId,
                Kilometres = route_m.Kilometres,
                RouteId = route_m.RouteId,
                CityArr = route_m.CityArr,
                CityDepart = route_m.CityDepart
                //CityArr = route_vm.CityArr
                ////CityDepart=
            };
            database.Routes.Update(route);
            database.Save();
        }


        public ObservableCollection<CityViewModel> GetAllCitiesForRoute()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityViewModel>();
                cfg.CreateMap<Route, RouteViewModel>();
            });
            var mapper = config.CreateMapper();
            var cities = mapper.Map<ObservableCollection<CityViewModel>>(database.Cities.GetAll());
            return cities;
        }
    }
}
