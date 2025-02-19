using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Models.PaymentModels
{
    public class ListPaymentVm
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Customer { get; set; }
    }
}
