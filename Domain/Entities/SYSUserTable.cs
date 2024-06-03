using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SYSUserTable
    {
        public string? UserName { get; set; }
        [NotMapped]
        public string? EmplName { get; set; }
        public string? EmployeeID { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? GroupID { get; set; }
        public bool Active { get; set; } = true;
        public string? EmplID { get; set; }
    }
}
