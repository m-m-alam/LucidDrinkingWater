using Lucid.Web.Models.Sales;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Models.PurchaseModels
{
    public class CreatePurchaseVm
    {
        public CreatePurchaseVm()
        {
            PurchaseDetails = new List<CreatePurchaseDetailsVm>();
        }
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }
              
        [Display(Name = "Date")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Total Amount")]
        public double Cost { get; set; }
        public double TotalAmount { get; set; }
        public double Payment { get; set; }
        public SelectList? Products { get; set; }
        public List<CreatePurchaseDetailsVm> PurchaseDetails { get; set; }
    }
}
