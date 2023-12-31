using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Service.Helpers
{
    public interface IPdfHelper
    {
        Task<MemoryStream> GeneratePdf(double salary);
    }
}
