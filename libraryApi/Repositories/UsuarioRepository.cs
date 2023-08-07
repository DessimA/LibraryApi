using libraryApi.Data;
using libraryApi.Models;

namespace libraryApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LibraryDbContext _dbContext;

        public UsuarioRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Usuario> GetAll()
        {
            return _dbContext.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _dbContext.Usuarios.FirstOrDefault(u => u.Id == id)!;
        }

        public void Add(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                _dbContext.SaveChanges();
            }
        }
    }
}
