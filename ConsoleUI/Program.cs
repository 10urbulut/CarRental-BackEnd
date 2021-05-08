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

            //EKRANA YAZMIYOR!!!
            //GetRentalDetails();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var car in rentalManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId+"/  "+car.RentDate + "/  "+car.ReturnDate);
            } 

        }

        private static void GetRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(
                    rental.BrandId +
                    rental.BrandName +
                    rental.ColorName +
                    rental.FirstName);
            }
        }

        private static void GetCarByCarIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarByCarId(2);

            Console.WriteLine(result.Message);
            Console.WriteLine(result.Data.Description);

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

            //var result = carManager.GetCarsByColorId(2);
            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.Description);
            }

        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

        }

        private static void GetCarDetailDtosTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

        }
    }
}
