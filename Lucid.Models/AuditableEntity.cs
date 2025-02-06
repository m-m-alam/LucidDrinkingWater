using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models
{
    public abstract class AuditableEntity : IEntity
    {
        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}
