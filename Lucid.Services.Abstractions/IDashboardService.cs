using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.ViewModel;

namespace Lucid.Services.Abstractions
{
    public interface IDashboardService
    {
        DashboardVm GetDashboard();
    }
}
