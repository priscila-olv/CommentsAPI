using Microsoft.EntityFrameworkCore;
using APIComments.Context;
using APIComments.Models;

namespace APIComments.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(APICommentsContext context) : base(context)
        {

        }
        public IEnumerable<Post> GetPostsComentarios()
        {
            return Get().Include(x => x.Comentarios);
        }

       
    }
}
