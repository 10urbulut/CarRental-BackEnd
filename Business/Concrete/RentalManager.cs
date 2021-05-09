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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
           if( rental.ReturnDate==null )
            {
                return new ErrorResult(Messages.CarReturnError);
            }
            else
            {
                  _rentalDal.Add(rental);
                return new SuccessResult(Messages.ContentAdded);
            }
             
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ContentDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ContentsListed);
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), Messages.ContentsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {

            return new SuccessDataResult<List<RentalDetailDto>> (_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ContentUpdated);
        }
    }
}
