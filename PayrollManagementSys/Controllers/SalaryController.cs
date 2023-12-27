using Microsoft.AspNetCore.Mvc;
using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Service.Services.Abstract;

namespace PayrollManagementSys.Web.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeService employeeService;

        public SalaryController(IUnitOfWork unitOfWork,IEmployeeService employeeService )
        {
            this.unitOfWork = unitOfWork;
            this.employeeService = employeeService;
        }
        public async Task<IActionResult> EmployeSalary()
        {
            var employees = await employeeService.GetAllEmployeeAsync(); 
            return View(employees);
        }
        public async Task<IActionResult> EmployeeWork()
        {
            return View();
        }
    }
}
