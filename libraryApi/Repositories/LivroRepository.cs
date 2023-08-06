using System.Collections.Generic;
using System.Linq;
using libraryApi.Data;
using libraryApi.Models;

namespace libraryApi.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LibraryDbContext _dbContext;

        public LivroRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Livro> GetAll()
        {
            return _dbContext.Livros.ToList();
        }

        public Livro GetById(int id)
        {
            return _dbContext.Livros.FirstOrDefault(l => l.Id == id)!;
        }

        public void Add(Livro livro)
        {
            _dbContext.Livros.Add(livro);
            _dbContext.SaveChanges();
        }

        public void Update(Livro livro)
        {
            _dbContext.Livros.Update(livro);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var livro = _dbContext.Livros.FirstOrDefault(l => l.Id == id);
            if (livro != null)
            {
                _dbContext.Livros.Remove(livro);
                _dbContext.SaveChanges();
            }
        }
    }
}
