using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaABC.Models;
using PracticaABC.Models.ViewModel;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PracticaABC.Controllers
{
	[Authorize]
	public class HomeController : Controller
    {

		private readonly AbcContext _AbcContext;
        public HomeController(AbcContext abcContext)
        {
			_AbcContext = abcContext;
        }

        public IActionResult Index()
        {
            List<ProductoDistribucion> list = _AbcContext.ProductoDistribucions.Include(c => c.IdDistNavigation).Include(c => c.IdEstibaNavigation).Include(c => c.IdTipoProdNavigation).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult ProductoDetalle(int idProducto)
        {
            ViewProducto viewProducto = new ViewProducto() {
                idProducto = new ProductoDistribucion(),
                selectListEstiba = _AbcContext.Estibas.Select(estiba => new SelectListItem() {
                    Text = estiba.Nombre,
                    Value = estiba.IdEstiba.ToString()
                }).ToList(),
                selectListTipoDist = _AbcContext.TipoDistribucions.Select(TipoDistribucion => new SelectListItem()
                {
                    Text = TipoDistribucion.Nombre,
                    Value = TipoDistribucion.IdDist.ToString()
                }).ToList(),
                selectListTipoProd = _AbcContext.TipoProductos.Select(TipoProductos => new SelectListItem()
                {
                    Text = TipoProductos.Descripcion,
                    Value = TipoProductos.IdTipoProd.ToString()
                }).ToList()
            };
            if(idProducto != 0) {
                viewProducto.idProducto = _AbcContext.ProductoDistribucions.Find(idProducto);
            }
            return View(viewProducto);
        }

        [HttpPost]
        public IActionResult ProductoDetalle(ViewProducto viewProducto)
        {
            if (viewProducto.idProducto.IdProducto == 0)
            {
                _AbcContext.ProductoDistribucions.Add(viewProducto.idProducto);
            }
            else { 
                _AbcContext.ProductoDistribucions.Update(viewProducto.idProducto);
            }

            _AbcContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public async Task<IActionResult> LogOut()
		{
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Inicio");
		}

        
    }
}