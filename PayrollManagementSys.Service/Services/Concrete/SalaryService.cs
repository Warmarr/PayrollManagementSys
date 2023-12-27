using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Entity.DTOs.Salaries;
using PayrollManagementSys.Entity.Entities;
using PayrollManagementSys.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Service.Services.Concrete
{
    public class SalaryService: ISalaryService
    {
        private readonly IUnitOfWork unitOfWork;

        public SalaryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task SalaryAddAsync(SalaryAddDto salaryAddDto)
        {
            await unitOfWork.GetRepository<Salary>().SalaryAddAsync(salaryAddDto);
            await unitOfWork.SaveAsync();
        }
    }
}
