using APIComments.Context;

namespace APIComments.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ComentarioRepository _comentarioRepo;
        private PostRepository _postRepo;
        public APICommentsContext _context;

        public UnitOfWork(APICommentsContext context)
        {
            _context = context;
        }


        public IComentarioRepository ComentarioRepository
        {
            get
            {
                return _comentarioRepo = _comentarioRepo ?? new ComentarioRepository(_context);
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                return _postRepo = _postRepo ?? new PostRepository(_context);
            }
        }


        public void Commit()
        {
           _context.SaveChanges();
        }

        public void Disponse()
        {
            _context.Dispose();
        }

    }
}
