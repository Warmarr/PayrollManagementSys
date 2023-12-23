using Microsoft.AspNetCore.Mvc;
using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Entity.Entities;

namespace PayrollManagementSys.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Employees()
        {
            var kisiler = await unitOfWork.GetRepository<AppUser>().GetAllAsync();
            return View(kisiler);
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeAdd()
        {
            return View();
        }
        
    }
}
