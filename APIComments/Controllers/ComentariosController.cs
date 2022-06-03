using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIComments.Context;
using APIComments.Models;


namespace APIComments.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly APICommentsContext _context;

        public ComentariosController(APICommentsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comentario>> Get()
        {
            var comentarios = _context.Comentarios.AsNoTracking().ToList();
            if (comentarios is null)
            {
                return NotFound("Comentários não encontrados");
            }
            return comentarios;
        }

        [HttpGet("{id:int}", Name = "ObterComentario")]
        public ActionResult<Comentario> Get(int id)
        {
            var comentario = _context.Comentarios.FirstOrDefault(c => c.Id == id );
            if (comentario is null)
            {
                return NotFound("Comentário não encontrado");
            }
            return comentario;
        }

        [HttpPost]
        public ActionResult Post(Comentario comentario)
        {
            if (comentario is null)
                return BadRequest();

            _context.Comentarios.Add(comentario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterComentario",
                new { id = comentario.Id }, comentario);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Comentario comentario)
        {
            if (id != comentario.Id)
            {
                return BadRequest();
            }

            _context.Entry(comentario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(comentario);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var comentario = _context.Comentarios.FirstOrDefault(c => c.Id == id);

            if (comentario is null)
            {
                return NotFound("Comentário não encontrado");
            }

            _context.Comentarios.Remove(comentario);
            _context.SaveChanges();

            return Ok(comentario);
        }
    }
}
