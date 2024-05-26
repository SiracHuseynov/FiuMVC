using Fiu.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiu.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFurnitureService _furnitureService;

        public HomeController(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public IActionResult Index()
        {
            var furnitures = _furnitureService.GetAllFurnitures();
            return View(furnitures);
        }


    }
}
