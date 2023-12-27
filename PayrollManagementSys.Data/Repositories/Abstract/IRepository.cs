using PayrollManagementSys.Entity.DTOs.Employees;
using PayrollManagementSys.Entity.DTOs.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Data.Repositories.Abstract
{
    public interface IRepository<T> where T : class,new()
    {
        Task AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null, params Expression<Func<T,object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        Task DepartmanAddAsync(string departmanName);
        Task DepartmanUpdateAsync(string departmanName, int departmanId);
        Task DepartmanSafeDelete(int departmanId);
        Task EmployeeAddAsync(EmployeeAddDto employeeAddDto, string password);
        Task EmployeeUpdateAsync(EmployeeUpdateDto employeeUpdateDto);
        Task EmployeeSafeDeleteAsync(int userId);
        Task<int> GetLastEmployeeIdAsync();
        Task SalaryAddAsync(SalaryAddDto salaryAddDto);

    }
}
