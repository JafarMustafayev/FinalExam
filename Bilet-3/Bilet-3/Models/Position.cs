using System.ComponentModel.DataAnnotations;

namespace Bilet_3.Models
{
    public class Position
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Name { get; set; }

        public List<Team>? Teams { get; set; }
    }
}
