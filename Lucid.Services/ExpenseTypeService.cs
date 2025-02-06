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
    public class ExpenseTypeService : Service<ExpenseType>, IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        public ExpenseTypeService(IExpenseTypeRepository expenseTypeRepository) : base(expenseTypeRepository) 
        {
            _expenseTypeRepository = expenseTypeRepository;
        }
    }
}
