using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Services.PaymentServices
{
    public class PaymentService : Service<Payment>, IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository):base(repository) 
        {
            _repository = repository;
        }
    }
}
