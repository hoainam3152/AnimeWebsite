using System.ComponentModel.DataAnnotations;

namespace AccountService.DTOs.Requests
{
    public class RoleCreateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
