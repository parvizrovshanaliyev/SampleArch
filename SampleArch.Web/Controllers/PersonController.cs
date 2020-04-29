using Microsoft.AspNetCore.Mvc;

namespace SampleArch.Web.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}