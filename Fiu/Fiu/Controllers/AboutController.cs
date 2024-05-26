using Fiu.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Fiu.Controllers
{
    public class AboutController : Controller
    {

       

        public IActionResult Index()
        {
            return View();
        }
    }
}
