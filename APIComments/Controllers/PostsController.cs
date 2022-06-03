using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIComments.Context;
using APIComments.Models;

namespace APIComments.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly APICommentsContext _context;
         public PostsController(APICommentsContext context)
        {
            _context = context;
        }

        [HttpGet("comentarios")]
        public ActionResult<IEnumerable<Post>> GetPostsComentarios()
        {

            return _context.Posts.Include(c => c.Comentarios).AsNoTracking().ToList();
            
        }


        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            var posts = _context.Posts.AsNoTracking().ToList();
            if (posts is null)
            {
                return NotFound("Comentários não encontrados");
            }
            return posts;
        }

        [HttpGet("{id:int}", Name = "ObterPost")]
        public ActionResult<Post> Get(int id)
        {
            var post = _context.Posts.FirstOrDefault(c => c.PostId == id );
            if (post is null)
            {
                return NotFound("Post não encontrado");
            }
            return post;
        }

        [HttpPost]
        public ActionResult Post(Post post)
        {
            if (post is null)
                return BadRequest();

            _context.Posts.Add(post);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPost",
                new { id = post.PostId }, post);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(post);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var post = _context.Comentarios.FirstOrDefault(c => c.Id == id);

            if (post is null)
            {
                return NotFound("Post não encontrado");
            }

            _context.Comentarios.Remove(post);
            _context.SaveChanges();

            return Ok(post);
        }
    }
}
