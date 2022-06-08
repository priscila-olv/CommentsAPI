using APIComments.Models;

namespace APIComments.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsComentarios();
    }
    
}
