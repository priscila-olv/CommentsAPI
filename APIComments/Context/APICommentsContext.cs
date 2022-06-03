using Microsoft.EntityFrameworkCore;
using APIComments.Models;

namespace APIComments.Context
{
    public class APICommentsContext : DbContext
    {
        public APICommentsContext(DbContextOptions<APICommentsContext> options) : base (options)
        {
        }

        public DbSet<Post>? Posts { get; set; }
        public DbSet<Comentario>? Comentarios { get; set; }

    }
}
