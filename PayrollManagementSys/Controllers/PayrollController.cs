using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollManagementSys.Entity.DTOs.Salaries;
using PayrollManagementSys.Entity.Entities;
using PayrollManagementSys.Service.Helpers;
using PayrollManagementSys.Service.Services.Abstract;
using PayrollManagementSys.Service.Services.Concrete;

namespace PayrollManagementSys.Web.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ISalaryService salaryService;
        private readonly IPayrollService payrollService;
        private readonly IPdfHelper pdfHelper;

        public PayrollController(IEmployeeService employeeService,ISalaryService salaryService,IPayrollService payrollService, IPdfHelper pdfHelper)
        {
            this.employeeService = employeeService;
            this.salaryService = salaryService;
            this.payrollService = payrollService;
            this.pdfHelper = pdfHelper;
        }
        [HttpGet]
        public async Task<IActionResult> PayrollEmployee()
        {
            var employees = await employeeService.GetAllEmployeeWithNonDeleted();


            return View(employees);
       
        }
        [HttpGet]
        public async Task<IActionResult> GetPayroll(int employeeId)
        {
            var employee = await employeeService.GetEmployeeById(employeeId);
            var salary = new SalaryAddDto
            {
                PersonelId = employeeId,
                User = employee
            };
            ViewBag.months = new SelectList(new List<string>{"Ocak","Şubat","Mart","Nisan","Mayıs","Haziran","Temmuz",
            "Ağustos","Eylül","Ekim","Kasım","Aralık"});
                
                
            return View(salary);
        }
        [HttpPost]
        public async Task<IActionResult> GetPayroll(SalaryAddDto salaryAddDto)
        {
            var employee = await employeeService.GetEmployeeById(salaryAddDto.PersonelId);
            var salary = new SalaryAddDto
            {
                PersonelId = salaryAddDto.PersonelId,
                User = employee
            };

            var salaryAmount =  await payrollService.GetPaymentInfo(salaryAddDto.PersonelId, salaryAddDto.SalaryDate.Date.Month, salaryAddDto.SalaryDate.Date.Year);
            var pdfStream = await payrollService.CreatePayrollAsync(salaryAmount.PaymentAmount);
            return File(pdfStream, "application/pdf",$"{salaryAddDto.User.FirstName}_{salaryAddDto.User.LastName}_Bordro.pdf");


           
           
        }
    }
}
