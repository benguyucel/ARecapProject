using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageMenager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageMenager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage,IFormFile file)
        {
            var result = BusinessRules.Run(CheckImageLimit(carImage));
            if (result!=null)
            {
                return result;
            }
            else
            {
                carImage.ImagePath= FileHelper.Upload(file);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ImageUpload);
            }
         
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldPath = _carImageDal.Get(x => x.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.Update(file, oldPath);
           _carImageDal.Update(carImage);
           return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var filePath = _carImageDal.Get(x => x.Id == carImage.Id).ImagePath;
            FileHelper.Delete(filePath);
           _carImageDal.Delete(carImage);
           return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(
                _carImageDal.GetAll(i => i.CarId == carId));
        }
        public IDataResult<CarImage> GetImageById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == carImageId));
        }
        private  IResult CheckImageLimit(CarImage carImage)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carImage.CarId).Count;
            if (result < 5)
            {
                return new SuccessResult();

            }
            return new ErrorResult(Messages.ImageLimit);
        }
    }
}
