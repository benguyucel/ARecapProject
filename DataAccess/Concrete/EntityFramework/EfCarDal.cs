using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(int CarId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             where cr.Id== CarId
                             select new CarDetailDto

                             {
                                 CarId = cr.Id,
                                 CarName = cr.CarName,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = cr.DailyPrice,
                                 BrandId = cr.BrandId,
                                 ColorId = cr.ColorId,
                                 ImagePath = context.CarImages.Where(x => x.CarId == cr.Id).ToArray()

                             };

                return result.SingleOrDefault();

            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 CarName = cr.CarName,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = cr.DailyPrice,
                                 BrandId=cr.BrandId,
                                 ColorId=cr.ColorId,
                                 ImagePath = context.CarImages.Where(x => x.CarId == cr.Id).ToArray()
                                 
                             };

                return filter != null ? result.Where(filter).ToList() : result.ToList();
                             
            }
        }
    }
}
