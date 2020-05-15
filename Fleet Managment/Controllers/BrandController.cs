using Fleet_Managment.Models;
using Fleet_Managment_BLL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var models = modelService.GetAll().ToList();

            List<BrandAndModelListViewModel> lb = new List<BrandAndModelListViewModel>();
            foreach (var b in brands)
            {
                BrandAndModelListViewModel brandAndModel = new BrandAndModelListViewModel
                {
                    IdBrand = b.Id,
                    BrandName = b.Name,
                    Models = models
                            .Where(m => m.Brand.Id == b.Id)
                            .OrderBy(m => m.Name)
                            .ToList(),
                };
                lb.Add(brandAndModel);
            }

            return View(lb);
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