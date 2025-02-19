using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Models.PaymentModels
{
    public class CreatePaymentVm
    {
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustomerId { get; set; }
        public SelectList? Customers { get; set; }

    }
}
