using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context) 
        {
            
        }
    }
}
