using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Services.SaleServices
{
    public class SaleService : Service<Sale>, ISaleService
    {
        private readonly ISaleRepository _repository;
        private readonly ApplicationDbContext _context;

        public SaleService(ISaleRepository repository, ApplicationDbContext context) :base(repository) 
        {
            _repository = repository;
            _context = context;
        }

        public IList<Sale> GetAllCurrentDate()
        {
            return _context.Sales.Include(x=>x.Customer).Where(x=>x.SaleDate == DateTime.Today).ToList();
        }
    }
}
