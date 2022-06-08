using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIComments.Context;
using APIComments.Models;
using APIComments.Repository;

namespace APIComments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ComentariosController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet("nome")]
        public ActionResult<IEnumerable<Comentario>> GetByName()
        {
            return _uof.ComentarioRepository.GetByName().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comentario>> Get()
        {
            var comentarios =  _uof.ComentarioRepository.Get().ToList();
            if (comentarios is null)
            {
                return NotFound("Comentários não encontrados");
            }
            return comentarios;
        }

        [HttpGet("{id:int}", Name = "ObterComentario")]
        public ActionResult<Comentario> Get(int id)
        {
            var comentario = _uof.ComentarioRepository.GetById(c => c.Id == id);
            if (comentario == null)
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

            _uof.ComentarioRepository.Add(comentario);
            _uof.Commit();

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

            _uof.ComentarioRepository.Update(comentario);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var comentario = _uof.ComentarioRepository.GetById(c => c.Id == id);

            if (comentario is null)
            {
                return NotFound("Comentário não encontrado");
            }

            _uof.ComentarioRepository.Delete(comentario);
            _uof.Commit();

            return Ok();
        }
    }
}
