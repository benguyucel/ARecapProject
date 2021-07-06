using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarMenager : ICarService
    {
        ICarDal _carDal;

        public CarMenager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length <= 2)
            {
                return new ErrorResult("Ürün iki karakterden büyük olmalı");

            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult();

            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        //[SecuredOperation("cars.getall,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarsWithDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(x => x.BrandId == brandId), true);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<Car> GetCarsById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsWithColorOrBrandFilter(int colorId, int brandId)
        {
           
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(x => x.ColorId == colorId && x.BrandId == brandId));
        }
    }
}
