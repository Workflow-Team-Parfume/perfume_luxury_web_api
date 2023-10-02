using Microsoft.AspNetCore.Http;

namespace Core.Dtos.User
{
    public class EditUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
