namespace CapaTabla
{
    public class CTProductos
    {
        public string IDProductos { get; set; }
        public string Categoria { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        //public string descCategoria { get; set; }

        public CTProductos(string idProductos, string categoria, string nombreProducto, int cantidad, decimal precio)
        {
            IDProductos = idProductos.Trim();
            Categoria = categoria.Trim();
            NombreProducto = nombreProducto.Trim();
            Cantidad = cantidad;
            Precio = precio;
        }

        public CTProductos()
        {
        }
    }
}