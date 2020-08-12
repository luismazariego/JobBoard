using Microsoft.AspNetCore.Mvc;

namespace JobBoard.App.Controllers
{
    public class JobsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}