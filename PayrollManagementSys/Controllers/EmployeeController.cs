using Microsoft.AspNetCore.Mvc;
using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Entity.DTOs.Employees;
using PayrollManagementSys.Entity.Entities;
using PayrollManagementSys.Service.Services.Abstract;

namespace PayrollManagementSys.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeService employeService;
        private readonly IDepartmanService departmanService;

        public EmployeeController(IEmployeeService employeService,IDepartmanService departmanService)
        {

            this.employeService = employeService;
            this.departmanService = departmanService;
        }
        public async Task<IActionResult> Employees()
        {
            var employees = await employeService.GetAllEmployeeAsync();
            
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeAdd()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> EmployeeAdd(EmployeeDto employeeDto)
        {
           
            return View();
        }
    }
}
