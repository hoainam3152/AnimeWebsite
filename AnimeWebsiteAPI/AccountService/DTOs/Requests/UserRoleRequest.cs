using System.ComponentModel.DataAnnotations;

namespace AccountService.DTOs.Requests
{
    public class UserRoleRequest
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string RoleId { get; set; } = string.Empty;
    }
}
