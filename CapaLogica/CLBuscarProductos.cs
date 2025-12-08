using CapaBD;
using CapaTabla;
using System;
using System.Collections.Generic;

namespace CapaLogica
{
    public class CLBuscarProductos
    {
        CBDBuscarProductos buscarProductos = new CBDBuscarProductos();

        public List<CTProductosDGV> BuscarPorID(string idProducto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(idProducto))
                {
                    return null;
                }

                return buscarProductos.BuscarPorID(idProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica (BuscarPorID): " + ex.Message, ex);
            }
        }

        public List<CTProductosDGV> BuscarPorNombre(string nombreP)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreP))
                {
                    return new List<CTProductosDGV>(); // Lista vacía
                }

                return buscarProductos.BuscarPorNombre(nombreP);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica (BuscarPorNombre): " + ex.Message, ex);
            }
        }

        public List<CTProductosDGV> BuscarPorCategoria(string descripcionCategoria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(descripcionCategoria))
                {
                    return new List<CTProductosDGV>(); // Lista vacía
                }

                return buscarProductos.BuscarPorCategoria(descripcionCategoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica (BuscarPorCategoria): " + ex.Message, ex);
            }
        }
    }
}
