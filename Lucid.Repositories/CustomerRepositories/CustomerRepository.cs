using Lucid.Database;
using Lucid.Models;
using Lucid.Repositories.Abstractions;


namespace Lucid.Repositories.CustomerRepositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        
    }
}
