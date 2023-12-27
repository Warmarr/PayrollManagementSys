using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Entity.DTOs.Salaries
{
    public class SalaryAddDto
    {
        public int PersonelId { get; set; }
        public double SalaryCoefficient { get; set; }
        public double TaxDeduction { get; set; }
        public double SgkDeduction { get; set; }
    }
}
