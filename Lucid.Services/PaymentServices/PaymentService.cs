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

namespace Lucid.Services.PaymentServices
{
    public class PaymentService : Service<Payment>, IPaymentService
    {       
        private readonly ApplicationDbContext _context;
        public PaymentService(IPaymentRepository repository, ApplicationDbContext context) :base(repository) 
        {
            _context = context;
        }

        public override Payment GetById(int id)
        {
            return _context.Payments.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }
    }
}
