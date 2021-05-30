using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if (car.CarName.Length<=2)
            {
                throw new Exception("Car name must be bigger than two");
               
            }
            else if(car.DailyPrice<1)
            {
                throw new Exception("Car daaily price must be bigger than zero");
               
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public Car GetCarsById(int carId)
        {
            return _carDal.Get(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
