using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalMenager rentalMenager = new RentalMenager(new EfRentalDal());
            Rental rental = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now,ReturnDate=null };
            var result =  rentalMenager.Add(rental);
            Console.WriteLine(result.Message);
            
            //UserListedTest();

            //CustomerAddedAndListedTest();
            //UserAddedTest();
            //Test Et Ödevin son kısımları 
            ///10.Gün
            //CarAddTest();
            //CarUpdateTest();
            //CarDeleteTest();
            //GetCars();
            //GetBrandsTest();
            //GetBrandsByIdTest();
            //AddBrandTest();
            //BrandUpdateTest();
            //DeleteBrandTest();
            //GetBrandsTest();
            //AddColorTest();
            //ColorUpdateTest();
            //ColorDeleteTest();
            //GetColorsTest();
            //GetColorByIdTest();
            //GetCarDetails();

        }

        private static void UserListedTest()
        {
            UserMenager userMenager = new UserMenager(new EfUserDal());
            var users = userMenager.GetUsers();
            foreach (var item in users.Data)
            {
                Console.WriteLine(item.Id + ":" + item.FirstName + " - " + item.LastName);

            }
            Console.WriteLine(users.Message);
        }

        private static void CustomerAddedAndListedTest()
        {
            CustomerMenager customerMenager = new CustomerMenager(new EfCustomerDal());

            Customer customer = new Customer { UserId = 1, CompanyName = "A Firması" };
            Customer customer1 = new Customer { UserId = 2, CompanyName = "B Firması" };
            Customer customer2 = new Customer { UserId = 3, CompanyName = "C Firması" };
            Customer customer3 = new Customer { UserId = 4, CompanyName = "E Firması" };
            Customer customer4 = new Customer { UserId = 5, CompanyName = "F Firması" };
            Customer customer5 = new Customer { UserId = 6, CompanyName = "G Firması" };
            customerMenager.Add(customer);
            customerMenager.Add(customer1);
            customerMenager.Add(customer2);
            customerMenager.Add(customer3);
            customerMenager.Add(customer4);
            customerMenager.Add(customer5);
            foreach (var item in customerMenager.GetCustomers().Data)
            {
                Console.WriteLine(item.CompanyName);
            }
        }

        private static void UserAddedTest()
        {
            //UserMenager userMenager = new UserMenager(new EfUserDal());
            //User user = new User { FirstName = "Yücel", LastName = "Bengü", Email = "jyouryok@78zjx.com", PasswordHash = "81dc9bdb52d04dc20036dbd8313ed055" };
            //User user1 = new User { FirstName = "Burak", LastName = "Şirin", Email = "beydocarti@biyac.com", Password = "81dc9bdb52d04dc20036dbd8313ed055" };
            //User user2 = new User { FirstName = "Kenan", LastName = "Çavdar", Email = "ceknigolme@biyac.com", Password = "81dc9bdb52d04dc20036dbd8313ed055" };
            //User user3 = new User { FirstName = "Burak", LastName = "Kaya", Email = "kitruharza@biyac.com", Password = "81dc9bdb52d04dc20036dbd8313ed055" };
            //User user4 = new User { FirstName = "Alican", LastName = "Tahtalı", Email = "vestulakno@biyac.com", Password = "81dc9bdb52d04dc20036dbd8313ed055" };
            //User user5 = new User { FirstName = "Koray", LastName = "Aksu", Email = "mohamedbensl@codingfury.tv", Password = "81dc9bdb52d04dc20036dbd8313ed055" };
            //userMenager.Add(user);
            //userMenager.Add(user1);
            //userMenager.Add(user2);
            //userMenager.Add(user3);
            //userMenager.Add(user4);
            //userMenager.Add(user5);
        }

        private static void GetCarDetails()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            foreach (var item in carMenager.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarName + "/" + item.BrandName + "/" + item.ColorName + "/" + item.DailyPrice);
            }
        }

        private static void GetColorByIdTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            var colorResult = colorMenager.GetColorById(1);
            Console.WriteLine(colorResult.Data.Name);
        }

        private static void ColorDeleteTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            Color color = new Color { Id = 1002, Name = "Siyah" };
            colorMenager.Delete(color);
        }

        private static void ColorUpdateTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            Color color = new Color { Id = 1002, Name = "Siyah" };
            colorMenager.Update(color);
        }

        private static void AddColorTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            Color color = new Color { Name = "Kara" };
            colorMenager.Add(color);
        }

        private static void GetColorsTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            foreach (var item in colorMenager.GetColors().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void DeleteBrandTest()
        {
            BrandMenager brandMenager = new BrandMenager(new EfBrandDal());
            Brand brand = new Brand { Id = 1002, Name = "sofaş" };
            brandMenager.Delete(brand);
        }

        private static void BrandUpdate()
        {
            BrandMenager brandMenager = new BrandMenager(new EfBrandDal());
            Brand brand = new Brand { Id = 1002, Name = "sofaş" };
            brandMenager.Update(brand);
        }

        private static void AddBrandTest()
        {
            BrandMenager brandMenager = new BrandMenager(new EfBrandDal());
            brandMenager.Add(new Brand { Name = "Tofaş" });
        }

        private static void GetBrandsByIdTest()
        {
            BrandMenager brandMenager = new BrandMenager(new EfBrandDal());
            var brandResult = brandMenager.GetBrandById(1);
            Console.WriteLine(brandResult.Data.Name);
        }

        private static void GetBrandsTest()
        {
            BrandMenager brandMenager = new BrandMenager(new EfBrandDal());
            foreach (var item in brandMenager.GetBrands().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void CarDeleteTest()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            Car car = new Car { Id = 1002, BrandId = 4, ColorId = 6, CarName = "Aston Martin", DailyPrice = 440, Description = "Lorem impsum dollor", ModelYear = "2000" };
            carMenager.Delete(car);
        }

        private static void CarUpdateTest()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            Car car = new Car { Id = 1002, BrandId = 4, ColorId = 6, CarName = "Aston Martin", DailyPrice = 440, Description = "Lorem impsum dollor", ModelYear = "2000" };
            carMenager.Update(car);
        }

        private static void CarAddTest()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            carMenager.Add(new Car { BrandId = 4, ColorId = 2, CarName = "Aston Martin", DailyPrice = 440, Description = "Lorem impsum dollor", ModelYear = "2000" });
        }



        private static void GetCars()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            foreach (var car in carMenager.GetAll().Data)
            {
                Console.WriteLine("ID:{0} BrandID:{1} ColorID:{2} ModelYear:{3} DailyPrice:{4},Description:{5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }
        }
    }
}
