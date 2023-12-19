using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Entity.Entities
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public AppUser User { get; set; }   
        public double MonthlySalary { get; set; }
       
    }
}
