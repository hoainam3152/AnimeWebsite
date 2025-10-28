using Microsoft.AspNetCore.Identity;
using System.Data;

namespace AccountService.Entities
{
    public class UserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
