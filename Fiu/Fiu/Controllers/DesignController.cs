using Fiu.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Fiu.Controllers
{
    public class DesignController : Controller
    {
        private readonly IFurnitureService _furnitureService;

        public DesignController(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public IActionResult Index()
        {
            var features = _furnitureService.GetAllFurnitures();
            return View(features);
        }

    }
}
