using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


            var result = _rentalDal.GetAll(c => c.CarId == rental.CarId).OrderBy(c => c.ReturnDate).FirstOrDefault();
            if (result.ReturnDate!=null)
            {
               _rentalDal.Add(rental);

                return new SuccessResult(Messages.CarRented);
            }
            else
            {
                return new ErrorResult(Messages.AlreadyRent);


            }


        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> GetRentalById(int carId)
        {
          
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.CarId== carId));
        }

        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
