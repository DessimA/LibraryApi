using libraryApi.Models;
using libraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace libraryApi.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var livros = _livroRepository.GetAll();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _livroRepository.GetById(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Add(Livro livro)
        {
            _livroRepository.Add(livro);
            return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }
            _livroRepository.Update(livro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _livroRepository.Delete(id);
            return NoContent();
        }
    }
}