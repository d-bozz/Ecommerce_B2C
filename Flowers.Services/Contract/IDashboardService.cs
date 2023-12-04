using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flowers.DTO;

namespace Flowers.Services.Contract
{
    public interface IDashboardService
    {
        DashboardDTO Summary();
    }
}
