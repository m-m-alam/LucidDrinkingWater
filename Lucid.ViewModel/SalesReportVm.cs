using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.ViewModel
{
    public class SalesReportVm
    {
        public DateTime Date {  get; set; }
        public string Product {  get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        
        //public double? Payment { get; set; }
    }
}
