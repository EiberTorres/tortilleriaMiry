using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int IdProducto { get; set; }

    public decimal CantidadDisponible { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
