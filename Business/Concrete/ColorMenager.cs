using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorMenager : IColorService
    {
        IColorDal _colorDal;

        public ColorMenager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color car)
        {
            _colorDal.Add(car);
            return new SuccessResult();
        }

        public IResult Delete(Color car)
        {
            _colorDal.Delete(car);
            return new SuccessResult();

        }

        public IDataResult<Color> GetColorById(int colorId)
        {
            return new  SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

        public IDataResult<List<Color>> GetColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IResult Update(Color car)
        {
            _colorDal.Update(car);
            return new SuccessResult();
        }
    }
}
