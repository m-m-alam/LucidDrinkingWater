using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models
{
    public class PurchaseDetails : IEntity
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public Product Product { get; set; }
    }
}
