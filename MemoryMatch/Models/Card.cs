using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryMatch.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsMatched { get; set; }
        public bool IsFlipped { get; set; }
    }
}
