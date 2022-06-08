
using Microsoft.AspNetCore.Mvc;

using APIComments.Models;
using APIComments.Repository;

namespace APIComments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWork _context;
         public PostsController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("comentarios")]
        public ActionResult<IEnumerable<Post>> GetPostsComentarios()
        {

            return _context.PostRepository.GetPostsComentarios().ToList();
            
        }


        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            return _context.PostRepository.Get().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterPost")]
        public ActionResult<Post> Get(int id)
        {
            var post = _context.PostRepository.GetById(c => c.PostId == id );
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Post post)
        {
            

            _context.PostRepository.Add(post);
            _context.Commit();

            return new CreatedAtRouteResult("ObterPost",
                new { id = post.PostId }, post);
        }


        
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Post post)
            {
                if (id != post.PostId)
                {
                    return BadRequest();
                }

                _context.PostRepository.Update(post);
                _context.Commit();
                return Ok();
            }
        

    

        [HttpDelete("{id:int}")]
        public ActionResult<Post> Delete(int id)
        {
            var post = _context.PostRepository.GetById(c => c.PostId == id);

            if (post is null)
            {
                return NotFound("Post não encontrado");
            }

            _context.PostRepository.Delete(post);
            _context.Commit();

            return post;
        }
    }
}
