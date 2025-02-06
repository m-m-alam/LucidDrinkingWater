using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models
{
    public abstract class IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public IEntity()
        {
            this.IsDeleted = false;
            this.IsActive = true;
        }
    }
}
