using Microsoft.AspNetCore.Mvc;

namespace studyset.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
