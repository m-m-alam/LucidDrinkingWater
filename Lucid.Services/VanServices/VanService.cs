using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Services.VanServices
{
    public class VanService : Service<Van>, IVanService
    {
        private readonly IVanRepository _vanRepository;

        public VanService(IVanRepository vanRepository) : base(vanRepository)
        {
            _vanRepository = vanRepository;
        }
    }
}
