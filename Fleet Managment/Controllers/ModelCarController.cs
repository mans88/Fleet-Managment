using Fleet_Managment_BLL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Fleet_Managment.Controllers
{
    public class ModelCarController : Controller
    {
        private IModelService modelService;

        public ModelCarController(IModelService modelService)
        {
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelAvailable(int id)
        {
            var result = modelService
                                .GetAll()
                                .Where(m => m.Brand.Id == id);

            return View(result.OrderBy(x => x.Name));
        }

        [HttpGet]
        public IActionResult CreateModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateModel(ModelTO model)
        {
            var created = modelService.Insert(model);
            return RedirectToAction("ModelAvailable");
        }
    }
}