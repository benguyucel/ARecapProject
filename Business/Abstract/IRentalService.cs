using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetRentals();
        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
        IDataResult<Rental> GetRentalById(int carId);
        IResult CheckCarCanRent(Rental rental);
    }
}
