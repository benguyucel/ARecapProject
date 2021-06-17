using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("ImagePath"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage,file);
            if (result.Success!=false)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
          
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("ImagePath"))] IFormFile file, [FromForm] CarImage carImage)
        {

            _carImageService.Update(carImage, file);
            return Ok("Güncellendi");

        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage car)
        {
            _carImageService.Delete(car);
            return Ok("Silindi");
        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _carImageService.GetCarImages();
            return Ok(result);
        }
    }
}
