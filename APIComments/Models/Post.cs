using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIComments.Models
{
    public class Post
    {
        public Post()
        {
               Comentarios = new Collection<Comentario>();
        }
        [Key]
        public int PostId { get; set; }


        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
