using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarMenager carMenager = new CarMenager(new InMemoryCarDal());
            Car carItem = new Car { Id = 7, BrandId = 4, DailyPrice = 5, ColorId = 54, Description = "Merhaba güzel insanlar", ModelYear = "1992" };
            carMenager.Add(carItem);
            GetCars(carMenager);
            Console.WriteLine("-----------------------------------With Delete-----------------------------------");
            carMenager.Delete(carItem);
            GetCars(carMenager);
            Car carItem1 = new Car { Id = 8, BrandId = 4, DailyPrice = 5, ColorId = 54, Description = "Merhaba güzel", ModelYear = "1992" };

            carMenager.Add(carItem1);
            Car carItemToUpdate = new Car { Id = 8, ColorId = 54, BrandId = 4, DailyPrice = 5,  Description = "Yücel güzel", ModelYear = "1993" };


            Console.WriteLine("-----------------------------------With Update-----------------------------------");
            carMenager.Update(carItemToUpdate);
            GetCars(carMenager);
        }

        private static void GetCars(CarMenager carMenager)
        {
            foreach (var car in carMenager.GetAll())
            {
                Console.WriteLine("ID:{0} BrandID:{1} ColorID:{2} ModelYear:{3} DailyPrice:{4},Description:{5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }
        }
    }
}
