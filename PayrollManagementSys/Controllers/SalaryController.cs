using Microsoft.AspNetCore.Mvc;
using PayrollManagementSys.Data.UnitOfWorks;

namespace PayrollManagementSys.Web.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public SalaryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> EmployeSalary()
        {
            return View();
        }
    }
}
