using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
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
        private readonly IMapper mapper;
        private readonly IValidator<AppUser> validator;

        public EmployeeController(IEmployeeService employeService,IDepartmanService departmanService,IMapper mapper,IValidator<AppUser> validator)
        {

            this.employeService = employeService;
            this.departmanService = departmanService;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<IActionResult> Employees()
        {
            var employees = await employeService.GetAllEmployeeAsync();
            
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeAdd()
        {
            var departmans = await departmanService.GetAllDepartmanAsync();
            return View(new EmployeeAddDto { Departmans = departmans});
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(EmployeeAddDto employeeAddDto)
        {
            var departmans = await departmanService.GetAllDepartmanAsync();
            var map = mapper.Map<AppUser>(employeeAddDto);
            var result =  await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await employeService.CreateEmployeeAsync(employeeAddDto);
                return RedirectToAction("Employees", "Employee");
            }
            else
            {
                result.AddToModelState(this.ModelState);

            }
            return View(new EmployeeAddDto { Departmans=departmans});
           
        }
    }
}
