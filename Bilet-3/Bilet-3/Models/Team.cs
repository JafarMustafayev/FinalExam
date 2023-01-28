using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilet_3.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int PositionId { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string FUllName { get; set; }

        [StringLength(maximumLength:100)]
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Linkedin { get; set; }

        public Position? Position { get; set; }

    }
}
