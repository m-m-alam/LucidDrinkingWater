using Lucid.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Models.Sales
{
    public class CreateSaleVm
    {
        public CreateSaleVm()
        {
            SaleDetails = new List<CreateSaleDetailsVm>();
        }
        [Display(Name = "Invoice No")]
        public string? InvoiceNo { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Date")]
        public DateTime SaleDate { get; set; }
        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }
        public double? Payment { get; set; }
        public double? Discount { get; set; }
        public SelectList? Customers { get; set; }
        public SelectList? Products { get; set; }
        public List<CreateSaleDetailsVm> SaleDetails { get; set; }
    }
}
