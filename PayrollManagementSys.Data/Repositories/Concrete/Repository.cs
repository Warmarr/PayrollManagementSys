using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSys.Data.Context;
using PayrollManagementSys.Data.Repositories.Abstract;
using PayrollManagementSys.Entity.DTOs.Employees;
using PayrollManagementSys.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> table { get => dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public Task<int> CountAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(()=>table.Remove(entity));
        }

        public async Task<List<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = table;
           
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach(var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = table;
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach(var property in includeProperties)
                {
                    query.Include(property);
                }
            }
            return await query.SingleAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=>table.Update(entity));
            return entity;
        }
        public async Task DepartmanAddAsync(string departmanName)
        {
            var departmanNameParam = new SqlParameter("@Name", departmanName);
            await dbContext.Database.ExecuteSqlRawAsync("EXECUTE InsertDepartman @Name",parameters: new[] { departmanNameParam });
        }
        public async Task DepartmanUpdateAsync(string departmanName,int departmanId)
        {
            var departmanNameParam = new SqlParameter("@Name", departmanName);
            var departmanIdParam = new SqlParameter("@Id", departmanId);
            await dbContext.Database.ExecuteSqlRawAsync("EXECUTE UpdateDepartman @Id,@Name",parameters: new[] { departmanIdParam, departmanNameParam });

        }
        public async Task DepartmanSafeDelete(int departmanId)
        {
           
            var departmanIdParam = new SqlParameter("@Id", departmanId);
            var IsDeleted = new SqlParameter("@Deleted", 1);

            await dbContext.Database.ExecuteSqlRawAsync("EXECUTE sp_UpdateDepartmanIsDeleted @Id,@Deleted", parameters: new[] { departmanIdParam, IsDeleted });

        }
        public async Task EmployeeAddAsync(EmployeeAddDto employeeAddDto,string password)
        {
            var passwordParam = new SqlParameter("@Password", password);
            var firstNameParam = new SqlParameter("@FirstName", employeeAddDto.FirstName);
            var lastNameParam = new SqlParameter("@LastName", employeeAddDto.LastName);
            var genderParam = new SqlParameter("@Gender", employeeAddDto.Gender);
            var birthDateParam = new SqlParameter("@BirthDate", employeeAddDto.BirtDate);
            var departmanParam = new SqlParameter("@DepartmentId", SqlDbType.Int);
            departmanParam.Value = employeeAddDto.DepertmanId;
            var addressParam = new SqlParameter("@Address", employeeAddDto.Addres);
            var sgkNumParam = new SqlParameter("@SGKNumara", employeeAddDto.SGKNumara);
            var userNameParam = new SqlParameter("@UserName", employeeAddDto.UserName);
            var emailParam = new SqlParameter("@Email",employeeAddDto.Email);
            var phoneNumberParam = new SqlParameter("@PhoneNumber", employeeAddDto.PhoneNumber);

            await dbContext.Database.ExecuteSqlRawAsync("EXECUTE InsertEmployee @FirstName,@LastName,@Gender,@DepartmentId,@Address,@BirthDate,@SGKNumara,@UserName,@Email,@PhoneNumber,@Password", parameters: 
                new[] { firstNameParam, lastNameParam, genderParam, departmanParam, addressParam, birthDateParam,  sgkNumParam, userNameParam, emailParam, phoneNumberParam, passwordParam });

        }
    }
}
