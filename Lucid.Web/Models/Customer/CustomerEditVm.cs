using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Models.Customer
{
    public class CustomerEditVm
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
        public int VanId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public SelectList? VanSelectList { get; set; }
    }
}
