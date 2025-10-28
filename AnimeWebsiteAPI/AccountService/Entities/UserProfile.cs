namespace AccountService.Entities
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
