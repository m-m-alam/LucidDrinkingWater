using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Lucid.Repositories
{
    public class ExpenseRepository : Repository<Expense> , IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }        
    }
}
