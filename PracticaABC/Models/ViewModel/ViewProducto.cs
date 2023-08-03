using Microsoft.AspNetCore.Mvc.Rendering;

namespace PracticaABC.Models.ViewModel
{
    public class ViewProducto
    {
        public ProductoDistribucion idProducto { get; set; }
        

        public List<SelectListItem> selectListTipoProd { get; set; }
        public List<SelectListItem> selectListTipoDist { get; set; }
        public List<SelectListItem> selectListEstiba { get; set; }
    }
}
