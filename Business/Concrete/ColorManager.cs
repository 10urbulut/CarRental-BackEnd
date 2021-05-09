using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public IResult Add(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult(Messages.ContentAdded);
        }

        public IResult Delete(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult(Messages.ContentDeleted);
        }

        public IDataResult<List<Color>> GetAllColors()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll(), Messages.ContentsListed);
        }

        public IDataResult<Color> GetByColorId(int id)
        {
            return new SuccessDataResult<Color>
                (_colordal.Get(c => c.ColorId == id), Messages.ContentsListed);
        }

        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult(Messages.ContentUpdated);
        }
    }
}
