using System.ComponentModel.DataAnnotations;

namespace Lucid.Models
{
    public class Customer : AuditableEntity
    {
        public string CustomerNo { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public int StockJar { get; set; }
        public double DueAmount { get; set; }
        public DateTime LastSaleDate { get; set; }
        public int VanId { get; set; }
        

        public Van Van { get; set; }
        //public List<Payment> Payments { get; set; }
    }
}
