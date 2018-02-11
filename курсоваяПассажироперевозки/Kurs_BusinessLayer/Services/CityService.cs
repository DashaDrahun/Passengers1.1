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
using System.Windows;

namespace Kurs_BusinessLayer.Services
{
    public class CityService : ICityService
    {
        IUnitOfWork database;
        public CityService(string name)
        {
            database = new EFUnitOfWork(name);
        }

        public void CreateCity(CityViewModel city_vm)
        {
            // Конфигурирование AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CityViewModel, City>());
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            var city_m = mapper.Map<City>(city_vm);
            var allcities = GetAll();
            var res = database.Cities.Find(c=> c.Name==city_m.Name);
            if (res.Count<City>()==0)
            {
                database.Cities.Create(city_m);
                database.Save();
            }
            else MessageBox.Show("Город с таким именем существует в базе данных");
            
        }

        public void DeleteCity(CityViewModel city_vm)
        {
            // Конфигурирование AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CityViewModel, City>());
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            var city_m = mapper.Map<City>(city_vm);
            database.Cities.Delete(city_m);
            // если город используется в маршруте
            try
            {
                database.Save();
            }
            catch
            {
                MessageBox.Show("Нельзя удалить данный город, т.к. он используется в маршрутах");
            }
            
        }

        public CityViewModel Get(int id)
        {
            var city = database.Cities.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<City, CityViewModel>());
            var rescity = Mapper.Map<CityViewModel>(city);
            return rescity;
        }

        public ObservableCollection<CityViewModel> GetAll()
        {
            // Конфигурирование AutoMapper
            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<City, CityViewModel>();
           });
            var mapper = config.CreateMapper();
            // Отображение List<City> на ObservableCollection<CityViewModel>
            var cities = mapper.Map<ObservableCollection<CityViewModel>>(database.Cities.GetAll());
            return cities;
        }

        public void UpdateCity(CityViewModel city_vm)
        {
            // Конфигурирование AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CityViewModel, City>());
            var mapper = config.CreateMapper();
            // Отображение объекта CityViewModel на City
            var city_m = mapper.Map<City>(city_vm);
            database.Cities.Update(city_m);
            database.Save();
        }
    }
}
