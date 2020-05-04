using Fleet_Managment.Models;
using Fleet_Managment_BLL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Fleet_Managment.Controllers
{
    public class CarController : Controller
    {
        // private readonly IUnitOfWork unitOfWork;
        private ICarService carService;

        private IModelService modelService;
        private IBrandService brandService;
        private IFuelService fuelService;

        public CarController(ICarService carService, IBrandService brandService, IModelService modelService, IFuelService fuelService)
        {
            this.carService = carService ?? throw new ArgumentNullException(nameof(carService));
            this.brandService = brandService ?? throw new ArgumentNullException(nameof(carService));
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
            this.fuelService = fuelService ?? throw new ArgumentNullException(nameof(fuelService));
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
            List<BrandTO> brands = brandService.GetAll();
            List<ModelTO> models = modelService.GetAll();
            List<FuelTO> fuels = fuelService.GetAll();
            ViewBag.Brands = brands;
            ViewBag.Models = models;
            ViewBag.Fuels = fuels;

            return View();
        }

        [HttpPost]
        public IActionResult CreateCar(CarAddedViewModel carModel)
        {
            CarTO car = new CarTO
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

        public IActionResult Delete(int id)
        {
            var result = carService.RemoveById(id);
            return RedirectToAction("CarAvailable");
        }

        public IActionResult Update(int id)
        {
            var car = carService.GetById(id);

            CarAddedViewModel carModel = new CarAddedViewModel();

            carModel.Chassis = car.Chassis;
            carModel.Numberplate = car.Numberplate;
            carModel.VehicleStatus = car.VehicleStatus;
            carModel.StartDateContract = car.StartDateContract;
            carModel.Year = car.Year;
            carModel.EndDateContract = car.EndDateContract;
            carModel.Km = car.Km;
            //carModel.idBrand = car.Brand.Id;
            //carModel.idFuel = 1;
            //carModel.idModel = 1;
            // idModel = car.Brand.Models.Select(m => m.Id).FirstOrDefault(),

            return View(carModel);
        }
    }
}