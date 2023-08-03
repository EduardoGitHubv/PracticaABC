namespace PracticaABC.Models
{
	public class Producto
	{
		public int IdProducto { get; set; }
		public string? Nombre { get; set; }
		public int Precio_Mayor { get; set; }
		public int Precio_Menor { get; set; }
		public int Cantidad	 { get; set; }
		public int IdDist { get; set; }
		public int IdEstiba { get; set; }
		public int IdTipoProd { get; set; }
	}
}
