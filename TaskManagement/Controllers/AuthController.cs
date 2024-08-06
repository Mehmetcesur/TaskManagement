using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
