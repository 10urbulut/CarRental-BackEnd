using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByColorId(1))
            {
                Console.WriteLine("{0} ,{1} ,{2}, {3}",
                    car.CarId, car.ColorId, car.Description, car.DailyPrice);
            }

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAllByBrandId(1))
            //{
            //    Console.WriteLine("{0} , {1}", car.CarId,car.Description);
            //}

        }
    }
}
