using Microsoft.AspNetCore.Mvc;
using PracticaABC.Models;
using PracticaABC.Resources;
using PracticaABC.Users.Interface;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace PracticaABC.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public InicioController(IUsuarioService usuarioService){
            _usuarioService = usuarioService;
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario userFound = await _usuarioService.GetUsuarios(correo, Utilidades.EncryptClave(clave));

            if (userFound == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();

            }
            List<Claim> claim = new List<Claim>(){
                new Claim(ClaimTypes.Name, userFound.Correo)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authenticationProperties
                );
            return RedirectToAction("Index","Home");
        }
    }
}
