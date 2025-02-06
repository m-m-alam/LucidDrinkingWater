
using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;

namespace Lucid.Repositories.CustomerRepositories
{
    public class CustomerTypeRepository :Repository<CustomerType>, ICustomerTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerTypeRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
