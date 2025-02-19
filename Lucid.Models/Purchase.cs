using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models
{
    public class Purchase : AuditableEntity
    {
        public Purchase()
        {
            PurchaseDetails = new List<PurchaseDetails>();
        }

        public string InvoiceNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double TotalAmount { get; set; }
        public double Payment { get; set; }
        public List<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
