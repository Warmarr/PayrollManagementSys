using PayrollManagementSys.Entity.DTOs.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Service.Services.Abstract
{
    public interface ISalaryService
    {
        Task SalaryAddAsync(SalaryAddDto salaryAddDto);
    }
}
