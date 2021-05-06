using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCarDetailDtosTest();
            //GetCarsByBrandIdTest();
            //GetCarsByColorIdTest();
            //GetCarByCarIdTest();
            //CarAddTest();
            //DeleteTest();
            //UpdateTest();



        }

        private static void GetCarByCarIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarByCarId(2))
            {
                Console.WriteLine(car.CarId + " / " +
                    car.Description + " / " + car.DailyPrice);
            }
        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car
            {
                CarId = 4,
                BrandId = 5,
                ColorId = 4,
                DailyPrice = 285,
                ModelYear = 2019,
                Description = "Hatcback, Klima"
            };

            carManager.Update(car1);
        }

        private static void DeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();
            car.CarId = 1003;
            carManager.Delete(car);
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car
            {
                BrandId = 4,
                ColorId = 4,
                DailyPrice = 325,
                Description = "Hatchback, Navigasyon, " +
                "Sunroof, Performans aracı",
                ModelYear = 2019
            };
            carManager.Add(car1);
        }

        private static void GetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.ColorId + " / " +
                    car.Description + " / " + car.DailyPrice);
            }
            
            
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.BrandId + " / " +
                    car.Description + " / " + car.DailyPrice);
            }
        }

        private static void GetCarDetailDtosTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " / " +
                    car.ColorName + " / " + car.DailyPrice);
            }
        }
    }
}
