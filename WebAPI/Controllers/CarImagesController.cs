using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] Models.CarImage objectFile, [FromForm] Entities.Concrete.CarImage carImage)
        {

            if (objectFile == null)
            {

            }
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + Guid.NewGuid().ToString("D") + objectFile.Files.FileName))
            {
                objectFile.Files.CopyTo(fileStream);
                fileStream.Flush();

            }
            var result = _carImageService.Add(new Entities.Concrete.CarImage
            {
                CarId = carImage.CarId,
                ImagePath = path + Guid.NewGuid().ToString("D") + objectFile.Files.FileName,
                Date = DateTime.Now
            });
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success ==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarıd")]
        public IActionResult GetCarId(int carId)
        {
            var result = _carImageService.GetImageByCarId(carId);
            if (result.Success ==true)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
    }
}
