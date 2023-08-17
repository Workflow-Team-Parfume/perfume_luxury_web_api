using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Dtos.User
{
    public class GetUserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string? PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
