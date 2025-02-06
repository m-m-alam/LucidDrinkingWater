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
    public class ExpenseTypeRepository : Repository<ExpenseType>, IExpenseTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
