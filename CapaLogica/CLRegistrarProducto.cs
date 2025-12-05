using System;
using CapaBD;
using CapaTabla;

namespace CapaLogica
{
    public class CLProductos
    {
        // Instancia de la capa BD
        CBDRegistrarProductos bd = new CBDRegistrarProductos();

        public bool RegistrarProducto(CTProductos obj)
        {
            // ---- Validaciones de negocio ----
            if (string.IsNullOrWhiteSpace(obj.IDProducto))
                throw new Exception("Debe ingresar un código.");

            if (string.IsNullOrWhiteSpace(obj.NombreProducto))
                throw new Exception("Debe ingresar un nombre.");

            if (obj.PrecioUnidad <= 0)
                throw new Exception("El precio debe ser mayor que cero.");

            if (obj.Cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa.");

            if (obj.IDCategoria < 1 || obj.IDCategoria > 5)
                throw new Exception("Debe seleccionar una categoría válida.");

            try
            {
                // ---- Llamada a la capa BD ----
                return bd.RegistrarProducto(obj);
            }
            catch (Exception ex)
            {
                // Reenvía un mensaje más claro hacia la UI
                throw new Exception("Error al registrar el producto: " + ex.Message);
            }
        }
    }
}
