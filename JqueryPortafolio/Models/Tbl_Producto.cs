//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JqueryPortafolio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Producto
    {
        public int IdProducto { get; set; }
        public string ProductoNombre { get; set; }
        public decimal ProductoPrecio { get; set; }
        public int ProductoCantidad { get; set; }
        public string ProductoDescripcion { get; set; }
        public int IdProveedor { get; set; }
    
        public virtual Tbl_Proveedor Tbl_Proveedor { get; set; }
    }
}
