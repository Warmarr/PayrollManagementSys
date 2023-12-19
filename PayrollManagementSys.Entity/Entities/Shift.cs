using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Entity.Entities
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        public double ShiftWage { get; set; }
        public double Tax { get; set; }
        public int WorkingDayNumber { get; set; }
        public double SalaryCoefficent { get; set; }
        public int TotalShiftCount { get; set; }


    }
}
