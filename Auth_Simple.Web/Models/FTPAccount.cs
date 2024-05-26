using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth_Simple.Web.Models
{
    [Table("SYS_FTPUser")]
    [Keyless]
    public class FTPAccount
    {
        public string  UserName { get; set; }
        public string  Domain { get; set; }
        public string  Password { get; set; }
    }
}
