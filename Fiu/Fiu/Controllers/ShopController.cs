using Microsoft.AspNetCore.Mvc;

namespace Fiu.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
