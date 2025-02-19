namespace Lucid.Web.Models.PurchaseModels
{
    public class ListPurchaseVm
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double TotalAmount { get; set; }
        public double Payment { get; set; }
    }
}
