namespace Backend_Personal_Doctor.Models.Users.DTOs
{
    public class UserDtoForCreate
    {
        public string firstname { get; set; } = null!;
        public string lastname { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!; 
    }
}