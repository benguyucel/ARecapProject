using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=300,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit",ModelYear="1920"},
                new Car{Id=2,BrandId=1,ColorId=1,DailyPrice=400,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit",ModelYear="1920"},
                new Car{Id=3,BrandId=1,ColorId=1,DailyPrice=500,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit",ModelYear="1920"},
                new Car{Id=4,BrandId=1,ColorId=1,DailyPrice=600,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit",ModelYear="1920"},
                new Car{Id=5,BrandId=1,ColorId=1,DailyPrice=600,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit",ModelYear="1920"},
                new Car{Id=6,BrandId=1,ColorId=1,DailyPrice=200,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit",ModelYear="1920"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("{0} the car Delete",car.Description);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            Car car = _cars.FirstOrDefault(c=>c.Id==carId);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
