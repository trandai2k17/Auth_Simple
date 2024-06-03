using Microsoft.AspNetCore.Identity;

namespace Auth_Simple.Web.ViewModels
{
    public class RoleVM
    {
        public string? RoleID { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public List<IdentityRole>? Roles{ get; set; }
    }
}
