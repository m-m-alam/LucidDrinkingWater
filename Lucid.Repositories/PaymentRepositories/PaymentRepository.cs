using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Repositories.PaymentRepositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
