using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models
{
    public class Payment : AuditableEntity
    {
        public double Amount {  get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustomerId {  get; set; }

        public Customer Customer { get; set; }
    }
}
