namespace Lucid.Web.Models.Customer
{
    public class CustomerListVm
    {
        public int Id { get; set; }
        public string CustomerNo { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public int StockJar { get; set; }
        public double DueAmount { get; set; }
        public DateTime LastSaleDate { get; set; }
        public string Van { get; set; }
    }
}
