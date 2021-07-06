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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetRentals();
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }

        [HttpGet("getrentalsdetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetRentalsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Message); }
        }

        [HttpGet("checkcanrent")]
        public IActionResult CheckCarCanRent(int carId, DateTime rentDate, DateTime returnDate)
        {
            Rental rental = new Rental { CarId = carId, RentDate = rentDate, ReturnDate = returnDate };
            var result = _rentalService.CheckCarCanRent(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
    }
}
