using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color car);
        IResult Update(Color car);
        IResult Delete(Color car);
        IDataResult<List<Color>> GetColors();
        IDataResult<Color> GetColorById(int colorId);
    }
}
