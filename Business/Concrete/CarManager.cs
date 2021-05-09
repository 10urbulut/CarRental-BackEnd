using Business.Abstract;
using Business.Constants;
using Core.Results;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ContentAdded);

            }
            
            return new ErrorResult(Messages.ContentNameInvalid);


        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccessResult(Messages.ContentDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>
                (_carDal.GetAll(),Messages.ContentsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c=>c.BrandId==id),Messages.ContentsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c=> c.ColorId==id),Messages.ContentsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails(),Messages.ContentsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult( Messages.ContentUpdated);
            
        }

       

        public IDataResult<List<Car>> GetCarByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max),Messages.ContentsListed);
        }

        public IDataResult<Car> GetCarByCarId(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c=>c.CarId==id),Messages.ContentsListed);
        }
    }
}