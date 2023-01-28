using System.ComponentModel.DataAnnotations;

namespace Bilet_3.ViewModel
{
    public class LoginViewModel
    {

        [Required]
        [StringLength(maximumLength: 50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 64, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
