using Microsoft.AspNetCore.Mvc;

namespace ADOPZ.WebApplication.Controllers
{
    public class CreateUserCommand : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
