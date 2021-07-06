using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 Id=rental.Id,
                                 FirstName=user.FirstName,
                                 LastName=user.LastName,
                                 BrandName=brand.Name,
                                 ColorName=color.Name,
                                 CarName=car.CarName,
                                 RentDate=rental.RentDate,
                                 ReturnDate=rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
