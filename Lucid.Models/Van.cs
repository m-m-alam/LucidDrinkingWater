using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models
{
    public class Van : AuditableEntity
    {
        public string Name { get; set; }
        public string Driver { get; set; }
        public string Mobile { get; set; }
    }
}
