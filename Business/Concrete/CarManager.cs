using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç eklendi.  " + car.Description);
            }
            else
            {
                Console.WriteLine("Lütfen 2 karakterden fazla ve" +
                    " fiyatı  sıfırdan büyük giriniz");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car); 
            Console.WriteLine("Araç silindi. " + car.CarId);
        }

        public List<Car> GetAll()
        {
           return  _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=>c.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c=> c.ColorId==id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.CarId+"  Araç güncellendi.  " + car.Description);
        }

       

        public List<Car> GetCarByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max);
        }

        public Car GetCarByCarId(int id)
        {
            return _carDal.Get(c=>c.CarId==id);
        }
    }
}