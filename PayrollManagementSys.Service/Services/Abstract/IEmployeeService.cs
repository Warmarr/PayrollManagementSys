using PayrollManagementSys.Entity.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Service.Services.Abstract
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployeeAsync();
    }
}
