using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetCarsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<CarDetailDto> GetCarDetail(int carId);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsWithDetails();
        IDataResult<List<CarDetailDto>> GetCarsWithColorOrBrandFilter(int colorId,int brandId);
    }
}
