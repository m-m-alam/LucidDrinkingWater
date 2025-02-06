using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Repositories.VanRepositories
{
    public class VanRepository : Repository<Van>, IVanRepository
    {
        private readonly ApplicationDbContext _context;

        public VanRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
