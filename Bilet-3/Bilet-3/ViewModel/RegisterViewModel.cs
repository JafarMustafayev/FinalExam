using System.ComponentModel.DataAnnotations;

namespace Bilet_3.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 64, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(maximumLength: 64, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
