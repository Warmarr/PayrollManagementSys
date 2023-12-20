using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Entity.Entities
{
    public class PaymentInfo
    {
        [Key]
        public int PaymentId { get; set; }
   
        public int PersonelId { get; set; }
        public AppUser User { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentDescription { get; set; }

    }
}
