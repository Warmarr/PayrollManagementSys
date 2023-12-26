﻿using PayrollManagementSys.Entity.DTOs.Departmans;
using PayrollManagementSys.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Entity.DTOs.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }  
        public DateTime StartedDate { get; set; }
        public DepartmanDto Departman { get; set; }


    }
}