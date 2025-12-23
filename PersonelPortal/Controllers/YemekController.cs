using Microsoft.AspNetCore.Mvc;

namespace PersonelPortal.Controllers
{
    public class YemekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
