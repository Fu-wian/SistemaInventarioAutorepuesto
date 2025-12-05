using System;
using CapaBD;
using CapaTabla;

namespace CapaLogica
{
    public class CLProductos
    {
        // Instancia de la capa BD
        CBDRegistrarProductos bd = new CBDRegistrarProductos();

        public void RegistrarProducto(CTProductos obj)
        {
            //Validaciones básicas
            if (string.IsNullOrWhiteSpace(obj.IDProducto))
                throw new Exception("Debe ingresar un código.");

            if (string.IsNullOrWhiteSpace(obj.NombreProducto))
                throw new Exception("Debe ingresar un nombre.");

            if (obj.PrecioUnidad <= 0)
                throw new Exception("El precio debe ser mayor que cero.");

            if (obj.Cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa.");

            if (obj.IDCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría válida.");

            // Llamada a la capa de BD
            bd.RegistrarProducto(obj);
        }
    }
}
