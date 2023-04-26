using Microsoft.AspNetCore.Mvc;

namespace PrivateClassApp.MVC.Areas.Admin.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
