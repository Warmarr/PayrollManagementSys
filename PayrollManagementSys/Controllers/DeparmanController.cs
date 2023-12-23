using Microsoft.AspNetCore.Mvc;
using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Entity.Entities;

namespace PayrollManagementSys.Web.Controllers
{
    public class DeparmanController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DeparmanController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> DepartmanPage()
        {
            var departmans = await unitOfWork.GetRepository<Departman>().GetAllAsync();
            return View(departmans);
        }
        [HttpGet]
        public async Task<IActionResult> DepartmanAdd()
        {
            return View();
        }
    }
}
