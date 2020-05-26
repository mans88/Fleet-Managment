using Fleet_Managment.Models;
using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_BLL.Services;
using FleetManagment.Shared.TransfertObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Fleet_Managment.Controllers
{
    public class ModelCarController : Controller
    {
        private IModelService modelService;
        private IBrandService brandService;

        public ModelCarController(IModelService modelService, IBrandService brandService)
        {
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
            this.brandService = brandService ?? throw new ArgumentNullException(nameof(brandService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateModel(int id)
        {
            ModelAddedViewModel model = new ModelAddedViewModel
            {
                IdBrand = id,
                BrandName = brandService.GetById(id).Name,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateModel(ModelAddedViewModel model)
        {
            var brand = brandService.GetById(model.IdBrand);
            ModelTO modelTO = new ModelTO
            {
                Name = model.ModelName,
                Brand = brand
            };
            var created = modelService.Insert(modelTO);
            return RedirectToAction("BrandAvailable", "Brand");
        }

        public IActionResult Details(int id)
        {
            var result = modelService
                            .GetAll()
                            .Where(x => x.Brand.Id == id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ModelTO model = modelService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ModelTO modelTO)
        {
            modelTO.Brand = modelService.GetById(modelTO.Id).Brand;
            modelService.Update(modelTO);
            var idBrand = modelTO.Brand.Id;
            return RedirectToAction("Details", new { id = idBrand });
        }

        public IActionResult Delete(int id)
        {
            var idBrand = modelService.GetById(id).Brand.Id;

            var result = modelService.RemoveById(id);

            return RedirectToAction("Details", new { id = idBrand });
        }
    }
}