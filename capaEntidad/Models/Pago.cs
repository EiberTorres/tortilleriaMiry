using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int VentaId { get; set; }

    public decimal MontoPagado { get; set; }

    public string MetodoPago { get; set; } = null!;

    public DateTime? FechaPago { get; set; }

    public virtual Venta Venta { get; set; } = null!;
}
