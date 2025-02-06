namespace Lucid.Web.Models.Sales
{
    public class ListSaleVm
    {
        public int Id { get; set; }        
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; }
        public double TotalAmount { get; set; }
        public double? Payment { get; set; }
    }
}
