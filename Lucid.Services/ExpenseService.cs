using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;

namespace Lucid.Services
{
    public class ExpenseService : Service<Expense>, IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository) : base(expenseRepository) 
        {
            _expenseRepository = expenseRepository;
        }

    }
}
