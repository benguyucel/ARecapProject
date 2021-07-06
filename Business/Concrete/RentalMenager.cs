using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Business.Concrete
{
    public class RentalMenager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalMenager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result =  BusinessRules.Run(CheckIfRentDateBiggerThanReturnDate(rental),CheckCarCanRent(rental));
            if (result!=null)
            {
                return result;
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> GetRentalById(int carId)
        {

            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));
        }

        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());

        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }


        public IResult CheckCarCanRent(Rental rental)
        {

            var results = _rentalDal.GetAll(c => c.CarId == rental.CarId);
            if (results != null)
            {
                var resultCanRent = results.Where(x => x.RentDate >= rental.RentDate || rental.ReturnDate <= x.ReturnDate).ToList();
                if (resultCanRent.Count != 0)
                {
                    return new ErrorResult();

                }

            }
            return new SuccessResult();
        }
        private IResult CheckIfRentDateBiggerThanReturnDate(Rental rental)
        {
            if (rental.RentDate < DateTime.Now || rental.ReturnDate < rental.RentDate)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
