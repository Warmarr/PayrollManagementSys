using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Entity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public int DepertmanId { get; set; }
        public Departman Departman { get; set; }
        public string Addres { get; set; }

        public ICollection<Departman> Departmans { get; set; }
        public ICollection<Salary> Salaries { get; set; }
    }
}
