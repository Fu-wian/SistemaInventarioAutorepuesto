using CapaBD;
using CapaTabla;
using System;
using System.Collections.Generic;

namespace CapaLogica
{
    public class CLEditarProductos
    {
        CBEditarProductos bd = new CBEditarProductos();

        // Buscar producto
        public CTProductos BuscarProducto(string idProducto)
        {
            if (string.IsNullOrWhiteSpace(idProducto))
                throw new Exception("Debe ingresar un ID.");

            return bd.BuscarProducto(idProducto);
        }


        // Eliminar producto
        public void EliminarProducto(string idProducto)
        {
            if (string.IsNullOrWhiteSpace(idProducto))
                throw new Exception("Debe ingresar un ID.");

            int result = bd.EliminarProducto(idProducto);

            if (result != 1)
                throw new Exception("No se pudo eliminar el producto.");
        }


        // Actualizar producto
        public int ActualizarProducto(CTProductos obj)
        {
            // VALIDACIONES DE NEGOCIO ------------------------------

            if (obj == null)
                throw new Exception("Objeto vacío.");

            if (string.IsNullOrWhiteSpace(obj.IDProducto))
                throw new Exception("Debe ingresar un ID.");

            if (obj.IDCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría válida.");

            if (string.IsNullOrWhiteSpace(obj.NombreProducto))
                throw new Exception("Debe ingresar un nombre de producto.");

            if (obj.Cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa.");

            if (obj.PrecioUnidad <= 0)
                throw new Exception("El precio debe ser mayor que 0.");

            // LLAMADA A BD -----------------------------------------

            int result = bd.ActualizarProducto(obj);

            return result;  // 1 = éxito, 0 = error
        }

    }
}