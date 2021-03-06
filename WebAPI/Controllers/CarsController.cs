using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetCarsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getwithdetails")]
        public IActionResult GetDetails()
        {
            var result = _carService.GetCarsWithDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }

        [HttpGet("cardetails")]
        public IActionResult GetCarDetail(int id)
        {
            var result = _carService.GetCarDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getByFilter")]
        public IActionResult GetByFilter(int colorId,int brandId)
        {
            var result = _carService.GetCarsWithColorOrBrandFilter(colorId,brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
    }
}
