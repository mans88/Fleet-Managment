using Fleet_Managment.Models;
using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment.Controllers
{
    public class CarController : Controller
    {
        // private readonly IUnitOfWork unitOfWork;
        private ICarService carService;

        private IBrandService brandService;

        public CarController(ICarService carService, IBrandService brandService)
        {
            this.carService = carService ?? throw new ArgumentNullException(nameof(carService));
            this.brandService = brandService ?? throw new ArgumentNullException(nameof(carService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarAvailable()
        {
            return View(carService.GetAll());
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            List<Brand> brands = brandService.GetAll();
            ViewBag.Brands = brands;
            return View();
        }

        [HttpPost]
        public IActionResult CreateCar(CarAddedViewModel carModel)
        {
            //var brand = brandService.GetById(carModel.Car.Brand.Id);
            //var car = carModel.Car;
            //car.Brand = brand;
            //carService.Insert(carModel.car);
            Car car = new Car
            {
                Brand = brandService.GetById(carModel.idBrand),
                Chassis = carModel.Chassis,
                Numberplate = carModel.Numberplate,
                VehicleStatus = carModel.VehicleStatus,
                StartDateContract = carModel.StartDateContract,
                Year = carModel.Year,
                EndDateContract = carModel.EndDateContract,
                Km = carModel.Km,
            };

            carService.Insert(car);
            return RedirectToAction("CarAvailable");
        }
    }
}