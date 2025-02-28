using Lucid.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;
        private readonly ICustomerService _customerService;
        public ReportController(IReportService service, ICustomerService customerService)
        {
            _service = service;
            _customerService = customerService;
        }

        public IActionResult SalesReport(DateTime startDate, DateTime endDate, int customerId)
        {
            if (startDate.Year == 1 || endDate.Year == 1) {
                endDate = DateTime.Now;
                startDate = endDate.AddDays(-1);
            }
            var saleReport = _service.CustomerSalesReport(startDate, endDate, customerId);    

            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;
            ViewBag.customers = new SelectList(_customerService.GetAll().ToList(), "Id", "Name", customerId);
            return View(saleReport);
        }
    }
}
