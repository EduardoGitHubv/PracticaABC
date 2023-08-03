using Microsoft.EntityFrameworkCore;
using PracticaABC.Models;
using PracticaABC.Users.Interface;

namespace PracticaABC.Users.Implement
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AbcContext _dbContext;
        public UsuarioService(AbcContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetUsuarios(string correo, string clave)
        {
            Usuario usuarioFound = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave)
                .FirstOrDefaultAsync();
            return usuarioFound;
        }
    }
}
