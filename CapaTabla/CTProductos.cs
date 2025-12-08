using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿namespace CapaTabla
{
    public class CTProductos
    {
        // ----- Campos reales de la tabla SQL -----
        public string IDProducto { get; set; }          // varchar(8)
        public int IDCategoria { get; set; }            // int
        public string NombreProducto { get; set; }      // varchar(100)
        public int Cantidad { get; set; }               // int
        public decimal PrecioUnidad { get; set; }       // decimal

        // ----- Campos adicionales para la vista (DGV) -----
        public string Categoria { get; set; }           // nombre de categoría
        public decimal Precio { get; set; }             // precio para mostrar

        // ----- Constructor vacío -----
        public CTProductos() {}

        // ----- Constructor para vista (DataGridView) -----
        public CTProductos(string idProducto, string categoria, string nombreProducto, int cantidad, decimal precio)
        {
            IDProducto = idProducto?.Trim();
            Categoria = categoria?.Trim();
            NombreProducto = nombreProducto?.Trim();
            Cantidad = cantidad;

            // Precio mostrado = PrecioUnidad
            Precio = precio;
            PrecioUnidad = precio;   // sincronización
        }
    }
}
