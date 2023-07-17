using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserEntity : IdentityUser
    {
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
