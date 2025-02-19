using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Services.Abstractions;
using Lucid.ViewModel;

namespace Lucid.Services
{
    public class DashboardService : IDashboardService
    {
        public DashboardVm GetDashboard() 
        { 
            return new DashboardVm();
        }
    }
}
