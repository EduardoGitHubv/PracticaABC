using Microsoft.EntityFrameworkCore;
using PracticaABC.Models;
namespace PracticaABC.Users.Interface
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);

    }
}
