﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Prog3.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompra = new HashSet<DetalleCompra>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int IdProducto { get; set; }
        public int? IdTipoProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int? Stock { get; set; }
        public string NombreProducto { get; set; }
        public double? Precio { get; set; }
        public string Imagen { get; set; }

        public virtual TipoProducto IdTipoProductoNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}