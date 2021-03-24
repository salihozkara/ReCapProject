using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImagesDto carImagesDto)
        {

            var result = _carImageService.Add(carImagesDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImagesDto carImagesDto)
        {

            var result = _carImageService.Update(carImagesDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpPost("add")]
        //public IActionResult Add(int id,[FromForm] IFormFile image)
        //{
        //    var result = _carImageService.Add(image,new CarImage(){CarId = id});
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
