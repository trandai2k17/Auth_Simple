using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SYSUserTable
    {
        public string? UserID { get; set; }
        public string? UserName { get; set; }
        [NotMapped]
        public string? Name { get; set; }
        public string? DomainUser { get; set; }
        public string? Password { get; set; }
        public string? GroupID { get; set; }
        public bool Active { get; set; } = true;
        public string? EmplID { get; set; }
    }
}
