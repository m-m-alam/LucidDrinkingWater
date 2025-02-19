using Microsoft.AspNetCore.Mvc;

namespace Lucid.Web.Controllers
{
    public class CustomerReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
