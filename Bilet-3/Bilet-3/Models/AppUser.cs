using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bilet_3.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength:30,MinimumLength =2)]
        public string Fullname { get; set; }
    }
}
