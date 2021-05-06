using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car> {
            new Car{CarId=1,BrandId=4,ColorId=1,DailyPrice=30000,ModelYear =2015,Description="Hatchback, Otomatik, Klimalı"},
            new Car{CarId=2,BrandId=3,ColorId=1,DailyPrice=30000,ModelYear =2016,Description="Hatchback, Düz Vites,Sunrooflu"},
            new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=305000,ModelYear =2021,Description="Sedan, Otomatik, Navigasyonlu"},
            new Car{CarId=4,BrandId=1,ColorId=1,DailyPrice=85000,ModelYear =2020,Description="Station, Otomatik, Klimalı, Sunrooflu"},
            new Car{CarId=5,BrandId=2,ColorId=2,DailyPrice=980000,ModelYear =2018,Description="Hatchback, Otomatik, Klimalı"},
            new Car{CarId=6,BrandId=2,ColorId=5,DailyPrice=123000,ModelYear =2019,Description="Station, Otomatik, Klimalı, Navigasyonlu, Sunrooflu"}

            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _car;
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c=>c.CarId==car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
