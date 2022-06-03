using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIComments.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        [StringLength(80)]
        public string? Email { get; set; }
        [Required]
        [StringLength(800)]
        public string? Body { get; set; }

        public int PostId { get; set; }

        [JsonIgnore]
        public Post? Post { get; set; }
    }
}
