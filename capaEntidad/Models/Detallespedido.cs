using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Detallespedido
{
    public int IdDetalle { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
