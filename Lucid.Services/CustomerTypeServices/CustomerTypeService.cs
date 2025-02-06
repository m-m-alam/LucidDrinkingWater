using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Services.CustomerTypeServices
{
    public class CustomerTypeService : Service<CustomerType>, ICustomerTypeService
    {
        private readonly ICustomerTypeRepository _repository;

        public CustomerTypeService(ICustomerTypeRepository repository) :base(repository)
        {
            _repository = repository;
        }
    }
}
