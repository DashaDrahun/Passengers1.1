using System.Data.Entity;
using System;
using Kurs_DataLayer.Entities;

namespace Kurs_DataLayer.EFContext
{
    class DataBaseInitialzer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        /* A database initializer is a class that takes care of database creation and initialization 
        in a Code First application. It is the job of database initializer to create the database 
        and required tables based on the data model classes you create.*/

        /*To see the Seed() method in action, you need to use 
        Database.SetInitializer(new DataBaseInitializer());*/
        protected override void Seed(EntityContext context)
        {
            City Minsk = new City { Name = "Минск" };
            City Svetlogorsk = new City { Name = "Светлогорск" };
            City Mogilev = new City { Name = "Могилев" };
            City Baranovichi = new City { Name = "Барановичи" };
            City Grodno = new City { Name = "Гродно" };
            City Gomel = new City { Name = "Гомель" };
            context.Cities.AddRange(new City[]
{
                Minsk,
                Svetlogorsk,
                Mogilev,
                Baranovichi,
                Grodno,
                Gomel
});
            Status succeed = new Status { Name = "Завершен успешно" };
            Status cancelled = new Status { Name = "Отменен" };
            Status inprocess = new Status { Name = "Действующий" };
            context.Statuses.AddRange(new Status[]
{
                succeed,
                cancelled,
                inprocess
});
            Route MiSvet = new Route
            {
                Kilometres = 222.2,
                CityArr = Minsk,
                CityDepart = Svetlogorsk,
            };
            Route SvetMin = new Route
            {
                Kilometres = 222.2,
                CityArr = Svetlogorsk,
                CityDepart = Minsk,
            };
            Route MogiBar = new Route
            {
                Kilometres = 332.9,
                CityArr = Mogilev,
                CityDepart = Baranovichi,
            };
            context.Routes.AddRange(new Route[]
{
                MiSvet,SvetMin,MogiBar
});
            Trip a = new Trip
            {
                Departure = new DateTime(2017, 11, 30, 19, 40, 0),
                Arrival = new DateTime(2017, 11, 30, 23, 10, 0),
                FreeSeetsNumber = 15,
                Price = 18.60,
                Route = MiSvet,
                Status = inprocess
            };
            Trip b = new Trip
            {
                Departure = new DateTime(2017, 12, 1, 15, 30, 0),
                Arrival = new DateTime(2017, 12, 1, 19, 10, 0),
                FreeSeetsNumber = 15,
                Price = 18.60,
                Route = SvetMin,
                Status = cancelled
            };

            Trip c = new Trip
            {
                Departure = new DateTime(2017, 12, 1, 15, 50, 0),
                Arrival = new DateTime(2017, 12, 1, 19, 10, 0),
                FreeSeetsNumber = 20,
                Price = 19.50,
                Route = MogiBar,
                Status = inprocess
            };

            Trip d = new Trip
            {
                Departure = new DateTime(2017, 10, 1, 12, 30, 0),
                Arrival = new DateTime(2017, 10, 1, 16, 50, 0),
                FreeSeetsNumber = 15,
                Price = 18.60,
                Route = MogiBar,
                Status = succeed
            };
            context.Trips.AddRange(new Trip[] { a, b, c,d });
            Client one = new Client
            {
                Family = "Лысюк",
                Name = "Елена",
                Patronymic = "Владимировна",
                Email = "lenusik@tut.by",
                DateBirth = new DateTime(1993, 8, 27),
                Tel_Mobile = "298562356"
            };
            Client two = new Client
            {
                Family = "Сугако",
                Name = "Ольга",
                Patronymic = "Валерьевна",
                Email = "mymail@tut.by",
                DateBirth = new DateTime(1993, 3, 24),
                Tel_Mobile = "29123654"
            };
            context.Clients.AddRange(new Client[] { one, two });
            context.SaveChanges();
        }
    }
}
