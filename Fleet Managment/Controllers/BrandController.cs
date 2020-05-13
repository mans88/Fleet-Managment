using Fleet_Managment_BLL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Fleet_Managment.Controllers
{
    public class BrandController : Controller
    {
        private IBrandService brandService;
        private IModelService modelService;

        public BrandController(IBrandService brandService, IModelService modelService)
        {
            this.brandService = brandService ?? throw new ArgumentNullException(nameof(brandService));
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BrandAvailable()
        {
            var brands = brandService.GetAll().ToList();

            return View(brands.OrderBy(x => x.Name));
        }

        public IActionResult Delete(int id)
        {
            var resultBrand = brandService.RemoveById(id);

            return RedirectToAction("BrandAvailable");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            BrandTO brand = brandService.GetById(id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Update(BrandTO brand)
        {
            brandService.Update(brand);
            return RedirectToAction("BrandAvailable");
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(BrandTO brand)
        {
            brandService.Insert(brand);

            return RedirectToAction("BrandAvailable");
        }
    }
}