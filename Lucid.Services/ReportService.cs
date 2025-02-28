using Lucid.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.ViewModel;
using Lucid.Database;
using Lucid.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Lucid.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService _customerService;

        public ReportService(ApplicationDbContext context, ICustomerService customerService) 
        {
            _context = context;
            _customerService = customerService;
        }
        public IList<SalesReportVm> CustomerSalesReport(DateTime startDate, DateTime endDate, int customerId)
        {
            var customer = _customerService.GetById(customerId);

            var sales = _context.Sales.Include(x=>x.SaleDetails).ThenInclude(c=>c.Product).Where(x=>x.CustomerId == customerId && x.SaleDate.Date >= startDate.Date && x.SaleDate.Date <= endDate.Date).ToList();
            var reports = new List<SalesReportVm>();
            foreach (var sale in sales) {
                foreach (var sDetails in sale.SaleDetails)
                {
                    var price = sDetails.Product.Name.ToLower() == "water jar"? customer.Price : sDetails.Product.Price;
                    var report = new SalesReportVm
                    {
                        Date = sale.SaleDate,
                        Product = sDetails.Product.Name,
                        Price = price,
                        Quantity = sDetails.Delivery,
                    };
                    reports.Add(report);
                }
            }
            return reports;
        }

    }
}
