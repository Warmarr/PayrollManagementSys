using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Entity.DTOs.Employees;
using PayrollManagementSys.Entity.DTOs.Salaries;
using PayrollManagementSys.Entity.Entities;
using PayrollManagementSys.Service.Services.Abstract;

namespace PayrollManagementSys.Web.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeService employeeService;
        private readonly ISalaryService salaryService;
        private readonly IMapper mapper;

        public SalaryController(IUnitOfWork unitOfWork,IEmployeeService employeeService,ISalaryService salaryService,IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.employeeService = employeeService;
            this.salaryService = salaryService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> EmployeSalary()
        {
            var employees = await employeeService.GetAllEmployeeWithNonDeleted();
          
          
            return View(employees);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeSalaryPost(int selectedMonth)
        {

            await salaryService.CalculateSalaryAsync();
            var id = selectedMonth;
            return RedirectToAction("EmployeSalary", "Salary");

        }
        [HttpGet]
        public async Task<IActionResult> SalaryEdit(int employeeId)
        {
            var employee = await employeeService.GetEmployeeById(employeeId);
            var viewModel = new WorkDaySalaryViewModel
            {
                WorkDay = new WorkDay { PersonelId = employeeId},
                
                Salary = new SalaryAddDto { PersonelId= employeeId }
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SalaryEdit(WorkDaySalaryViewModel viewModel)
        {

            var viewModel1 = new WorkDaySalaryViewModel
            {
                WorkDay = new WorkDay { PersonelId = viewModel.WorkDay.PersonelId },

                Salary = new SalaryAddDto { PersonelId = viewModel.WorkDay.PersonelId }
            };


            bool isSuccess = await salaryService.InsertWorkDayAsync(viewModel);
            bool isSuccessSalary = await salaryService.SalaryAddAsync(viewModel.Salary);


            if (isSuccess)
            {
                
                if (isSuccessSalary)
                {
                    return RedirectToAction("Index", "Home"); // Adjust as needed

                }
                else 
                {
                    TempData["ErrorSalary"] = "MAAŞ BİLGİ İŞLEMLERİ SIRASINDA HATA OLUŞTU!";
                    return View(viewModel1); // Adjust as needed
                }
            }
            else
            {
                // Return an error response or handle the error in some way
                TempData["Error"] = "AYNI AY VE YILDA ÇALIŞMA ZAMANI EKLENEMEZ!";
                return View(viewModel1); // Adjust as needed
            }


        }
  
    }
}
