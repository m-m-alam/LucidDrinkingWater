namespace Lucid.Models
{
    public class Sale:AuditableEntity
    {
        public Sale()
        {
            SaleDetails = new List<SaleDetails>();
        }

        public string InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalAmount { get; set; }
        public double? Payment { get; set; }
        public double? Discount { get; set; }

        public Customer Customer { get; set; }
        public List<SaleDetails> SaleDetails { get; set; }
    }
}
