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
    public class SalaryService : ISalaryService
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
        public async Task<bool> InsertWorkDayAsync(WorkDaySalaryViewModel viewModel)
        {

            int rowsAffected = await unitOfWork.GetRepository<WorkDay>().InsertWorkDayAsync(viewModel.WorkDay.PersonelId, viewModel.WorkDay.WorkDate, viewModel.WorkDay.WorkTime);
            await unitOfWork.SaveAsync();
            if (rowsAffected > 0)
            {
                return true;
            }
            else

                return false;




        }

        public async Task CalculateSalaryAsync()
        {
            var allEmployeeIds = await unitOfWork.GetRepository<WorkDay>().GetAllAsync(x => x.WorkDate != null);
            foreach (var employeeId in allEmployeeIds)
            {
                await unitOfWork.GetRepository<PaymentInfo>().CalculateSalary(employeeId.PersonelId);
            }
            await unitOfWork.SaveAsync();

        }
        public async Task<List<WorkDay>> GetWorkDateAsync()
        {
            var dates = await unitOfWork.GetRepository<WorkDay>().GetAllAsync();
            return dates;

        }
    }
}
