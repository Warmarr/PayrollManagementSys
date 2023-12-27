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
        private readonly IValidator<EmployeeDto> validatorUpdate;

        public EmployeeController(IEmployeeService employeService,IDepartmanService departmanService,IMapper mapper,IValidator<AppUser> validator,IValidator<EmployeeDto> validatorUpdate)
        {

            this.employeService = employeService;
            this.departmanService = departmanService;
            this.mapper = mapper;
            this.validator = validator;
            this.validatorUpdate = validatorUpdate;
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
            var roles = await employeService.GetAllRolesAsync();

            return View(new EmployeeAddDto { Departmans = departmans,Roles = roles });
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(EmployeeAddDto employeeAddDto)
        {
            var departmans = await departmanService.GetAllDepartmanAsync();
            var roles = await employeService.GetAllRolesAsync();

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
            return View(new EmployeeAddDto { Departmans=departmans,Roles = roles});
           
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeUpdate(int employeeId)
        {
            var employees = await employeService.GetEmployeeById(employeeId);

            var departmans = await departmanService.GetAllDepartmanAsync();
            
            var roles = await employeService.GetAllRolesAsync();
            var map = mapper.Map<EmployeeUpdateDto>(employees);
            map.Roles = roles;
            map.Departmans = departmans;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeUpdate(EmployeeUpdateDto employeeUpdateDto)
        {
            var employees = await employeService.GetEmployeeById(employeeUpdateDto.Id);

            var departmans = await departmanService.GetAllDepartmanAsync();

            var map = mapper.Map<EmployeeDto>(employeeUpdateDto);
            var result = await validatorUpdate.ValidateAsync(map);
            if (result.IsValid)
            {
                await employeService.EmployeeUpdateAsync(employeeUpdateDto);
                return RedirectToAction("Employees", "Employee");
            }
            else
                result.AddToModelState(this.ModelState);

;
            var roles = await employeService.GetAllRolesAsync();
            var updatemap = mapper.Map<EmployeeUpdateDto>(employees);
            updatemap.Roles = roles;
            updatemap.Departmans = departmans;
            return View(updatemap);
        }
        public async Task<IActionResult> EmployeeDelete(int userId)
        {
            await employeService.EmployeeSafeDeleteAsync(userId);
            return RedirectToAction("Employees", "Employee");
        }
    }
}
