using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Entity.Entities
{
    public class Departman
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
