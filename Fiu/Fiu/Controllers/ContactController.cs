using Microsoft.AspNetCore.Mvc;

namespace Fiu.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
