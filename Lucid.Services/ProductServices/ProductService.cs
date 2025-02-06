using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Services.ProductServices
{
    public class ProductService: Service<Product>, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository):base(repository) 
        {
            _repository = repository;
        }
    }
}
