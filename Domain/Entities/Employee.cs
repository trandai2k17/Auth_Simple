using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public string? HasAccount { get; set; }
    }
}
