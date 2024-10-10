using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int? UsuarioId { get; set; }

    public int? IdPedido { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal TotalVenta { get; set; }

    public int? TransaccionId { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Usuario? Usuario { get; set; }
}
