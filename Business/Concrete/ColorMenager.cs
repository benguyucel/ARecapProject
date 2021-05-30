using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorMenager : IColorService
    {
        IColorDal _colorDal;

        public ColorMenager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color car)
        {
            _colorDal.Add(car);
        }

        public void Delete(Color car)
        {
            _colorDal.Delete(car);
        }

        public void Update(Color car)
        {
            _colorDal.Update(car);
        }
    }
}
