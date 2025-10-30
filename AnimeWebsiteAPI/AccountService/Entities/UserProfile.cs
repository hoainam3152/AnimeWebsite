using System.ComponentModel.DataAnnotations;

namespace AccountService.Entities
{
    public class UserProfile
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
    }
}
