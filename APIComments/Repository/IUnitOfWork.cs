namespace APIComments.Repository
{
    public interface IUnitOfWork
    {
        IComentarioRepository ComentarioRepository { get; }
        IPostRepository PostRepository { get; }
        void Commit();
    }
}
