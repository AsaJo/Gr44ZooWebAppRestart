using Microsoft.AspNetCore.Mvc;

namespace Gr44ZooWebApp.Controllers
{
    public class VeterinaryController : Controller
    {
        // step one
        public IActionResult Index()// step 2 Create a view...
        {
            return View();
        }
    }
}
