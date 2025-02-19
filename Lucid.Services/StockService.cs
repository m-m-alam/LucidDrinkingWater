using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Services
{
    public class StockService : Service<Stock>, IStockService
    {       
        public StockService(IStockRepository repository) : base(repository) 
        {
            
        }
    }
}
