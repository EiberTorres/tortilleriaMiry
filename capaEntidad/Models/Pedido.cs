using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public DateTime? FechaPedido { get; set; }

    public decimal Total { get; set; }

    public decimal? Pagado { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Detallespedido> Detallespedidos { get; set; } = new List<Detallespedido>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
