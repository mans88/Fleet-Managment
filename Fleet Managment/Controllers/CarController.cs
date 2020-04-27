using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Fleet_Managment.Controllers
{
    public class CarController : Controller
    {
        // private readonly IUnitOfWork unitOfWork;
        private ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService ?? throw new ArgumentNullException(nameof(carService));
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
            return View();
        }

        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            carService.Insert(car);
            return RedirectToAction("CarAvailable");
        }
    }
}