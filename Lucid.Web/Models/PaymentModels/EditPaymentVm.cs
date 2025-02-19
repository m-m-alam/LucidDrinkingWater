using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Models.PaymentModels
{
    public class EditPaymentVm
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public SelectList? Customers { get; set; }
    }
}
