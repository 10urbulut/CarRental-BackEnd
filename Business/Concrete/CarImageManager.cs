using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Business;
using Core.Utilities.FileManager;
using Core.Utilities.Helper;

using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
       

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
           IResult result= BusinessRules.Run(CheckIfCarCanHaveFiveImagesAtMost(carImage.CarId));

            if (result  != null)
            {
                return result;
            }

            carImage.ImagePath = CarImagesFileHelper.Add(file);
            carImage.Date = DateTime.Now;
           _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            CarImagesFileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.ContentsListed);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        }

        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId);
          
            string path = @"Images\default.png";

         
           if  (!result.Any())
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            }
            return result;
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {

            CarImage oldCarImage = GetById(carImage.ImageId).Data;
            carImage.ImagePath = CarImagesFileHelper.Update(file, oldCarImage.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarId = oldCarImage.CarId;

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarCanHaveFiveImagesAtMost(int carId)
        {
           var result = _carImageDal.GetAll(c=>c.CarId==carId);
            if (result.Count<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarCanHaveFiveImagesAtMost);
        }
    }
}
