using APIComments.Context;
using APIComments.Models;

namespace APIComments.Repository
{
    public class ComentarioRepository : Repository<Comentario>, IComentarioRepository
    {
        public ComentarioRepository(APICommentsContext context) : base(context)
        {

        }
        public IEnumerable<Comentario> GetByName()
        {
            return Get().OrderBy(c => c.Name).ToList();
        }
    }

}