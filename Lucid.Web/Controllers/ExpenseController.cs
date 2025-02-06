using Lucid.Web.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;

namespace Lucid.Web.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(CreateProductVm model)
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            return View();
        }
        public IActionResult Delete(int? id)
        {
            return View();
        }
    }
}
