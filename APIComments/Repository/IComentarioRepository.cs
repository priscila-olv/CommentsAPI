using APIComments.Models;

namespace APIComments.Repository
{
    public interface IComentarioRepository : IRepository<Comentario>
    {
        IEnumerable<Comentario> GetByName();
    }
}
