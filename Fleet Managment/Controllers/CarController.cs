using Fleet_Managment.Models;
using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Interfaces;
using FleetManagment.Shared.Enumeration;
using FleetManagment.Shared.TransfertObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Fleet_Managment.Controllers
{
    public class CarController : Controller
    {
        private ICarService carService;
        private IModelService modelService;
        private IBrandService brandService;

        public CarController(ICarService carService, IBrandService brandService, IModelService modelService)
        {
            this.carService = carService ?? throw new ArgumentNullException(nameof(carService));
            this.brandService = brandService ?? throw new ArgumentNullException(nameof(carService));
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarAvailable()
        {
            var allCars = carService.GetAll();
            List<CarListingViewModel> cars = new List<CarListingViewModel>();

            foreach (var item in allCars)
            {
                CarListingViewModel carModel = new CarListingViewModel
                {
                    IdCar = item.Id,
                    Chassis = item.Chassis,
                    Numberplate = item.Numberplate,
                    VehicleStatus = item.VehicleStatus,
                    StartDateContract = item.StartDateContract,
                    Year = item.Year,
                    EndDateContract = item.EndDateContract,
                    Km = item.Km,
                    Model = item.Model,
                    Fuel = item.Fuel
                };
                cars.Add(carModel);
            }
            return View(cars);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            List<BrandTO> brands = brandService.GetAll();
            List<ModelTO> models = modelService.GetAll();

            ViewBag.Brands = brands;
            ViewBag.Models = models;
            return View();
        }

        [HttpPost]
        public IActionResult CreateCar(CarAddedViewModel carModel)
        {
            CarTO car = new CarTO
            {
                Model = modelService.GetById(carModel.IdModel),
                Chassis = carModel.Chassis,
                Numberplate = carModel.Numberplate,
                VehicleStatus = carModel.VehicleStatus,
                StartDateContract = carModel.StartDateContract,
                Year = carModel.Year,
                EndDateContract = carModel.EndDateContract,
                Km = carModel.Km,
                Fuel = carModel.Fuel,
            };

            carService.Insert(car);
            return RedirectToAction("CarAvailable");
        }

        public IActionResult Delete(int id)
        {
            var result = carService.RemoveById(id);
            return RedirectToAction("CarAvailable");
        }

        [HttpGet]
        public IActionResult GetModels(int id)
        {
            var result = modelService.GetAll()
                                     .Where(c => c.Brand.Id == id)
                                     .OrderBy(c => c.Name)
                                     .ToList();

            return PartialView(result);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CarTO car = new CarTO();
            car = carService.GetById(id);

            CarAddedViewModel carAdded = new CarAddedViewModel();
            carAdded.IdCar = id;
            carAdded.Chassis = car.Chassis;
            carAdded.Numberplate = car.Numberplate;
            carAdded.VehicleStatus = car.VehicleStatus;
            carAdded.StartDateContract = car.StartDateContract;
            carAdded.Year = car.Year;
            carAdded.EndDateContract = car.EndDateContract;
            carAdded.Km = car.Km;
            carAdded.IdBrand = car.Model.Brand.Id;
            carAdded.Fuel = car.Fuel;

            List<BrandTO> brands = brandService.GetAll();
            List<ModelTO> models = modelService.GetAll().Where(m => m.Brand.Id == carAdded.IdBrand).ToList();
            ViewBag.Brands = brands;
            ViewBag.Models = models;

            return View(carAdded);
        }

        [HttpPost]
        public IActionResult Update(CarAddedViewModel carModel)
        {
            CarTO car = new CarTO
            {
                Id = carModel.IdCar,
                Model = modelService.GetById(carModel.IdModel),
                Chassis = carModel.Chassis,
                Numberplate = carModel.Numberplate,
                VehicleStatus = carModel.VehicleStatus,
                StartDateContract = carModel.StartDateContract,
                Year = carModel.Year,
                EndDateContract = carModel.EndDateContract,
                Km = carModel.Km,
                Fuel = carModel.Fuel,
            };

            carService.Update(car);
            return RedirectToAction("CarAvailable");
        }
    }
}