using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car> {
            new Car{Id=1,BrandId=4,ColorId=1,DailyPrice=30000,ModelYear =2015,Description="Hatchback, Otomatik, Klimalı"},
            new Car{Id=2,BrandId=3,ColorId=1,DailyPrice=30000,ModelYear =2016,Description="Hatchback, Düz Vites,Sunrooflu"},
            new Car{Id=3,BrandId=3,ColorId=3,DailyPrice=305000,ModelYear =2021,Description="Sedan, Otomatik, Navigasyonlu"},
            new Car{Id=4,BrandId=1,ColorId=1,DailyPrice=85000,ModelYear =2020,Description="Station, Otomatik, Klimalı, Sunrooflu"},
            new Car{Id=5,BrandId=2,ColorId=2,DailyPrice=980000,ModelYear =2018,Description="Hatchback, Otomatik, Klimalı"},
            new Car{Id=6,BrandId=2,ColorId=5,DailyPrice=123000,ModelYear =2019,Description="Station, Otomatik, Klimalı, Navigasyonlu, Sunrooflu"}

            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c=>c.Id==car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
