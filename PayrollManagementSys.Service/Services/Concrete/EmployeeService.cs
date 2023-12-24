using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Entity.DTOs.Employees;
using PayrollManagementSys.Entity.Entities;
using PayrollManagementSys.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Service.Services.Concrete
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper,UserManager<AppUser> userManager,RoleManager
            <AppRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<List<EmployeeDto>> GetAllEmployeeAsync()
        {
            var employees = await unitOfWork.GetRepository<AppUser>().GetAllAsync(x=>!x.IsDeleted,x=>x.Departman);
            var map = mapper.Map<List<EmployeeDto>>(employees);

            return map;
        }
        public async Task<string> GetEmployeeRoleLogin(string email)
        {
            throw new NotImplementedException();
        }
    }
}
