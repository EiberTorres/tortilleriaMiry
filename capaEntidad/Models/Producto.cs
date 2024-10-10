using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string? LoteProducto { get; set; }

    public int ClaseProductoId { get; set; }

    public int ProveedorId { get; set; }

    public decimal Precio { get; set; }

    public virtual Clasesproducto ClaseProducto { get; set; } = null!;

    public virtual ICollection<Detallespedido> Detallespedidos { get; set; } = new List<Detallespedido>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
