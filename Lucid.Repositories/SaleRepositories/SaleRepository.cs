using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Repositories.SaleRepositories
{
    public class SaleRepository: Repository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
