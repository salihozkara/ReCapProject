using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {

            var result = _carService.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getcarsdetailbycolorid")]
        public IActionResult GetCarsDetailByColorId(int colorId)
        {
            var result = _carService.GetCarsDetailByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcarsdetailbybrandid")]
        public IActionResult GetCarsDetailByBrandId(int brandId)
        {
            var result = _carService.GetCarsDetailByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcarsdetailbycoloridandbrandid")]
        public IActionResult GetCarsDetailByColorIdAndBrandId(int colorId,int brandId)
        {
            var result = _carService.GetCarsDetailByColorAndBrand(colorId,brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
