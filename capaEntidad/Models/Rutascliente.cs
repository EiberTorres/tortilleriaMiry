using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Rutascliente
{
    public int IdRuta { get; set; }

    public int? IdCliente { get; set; }

    public string? PuntoInicio { get; set; }

    public string? PuntoDestino { get; set; }

    public decimal? Distancia { get; set; }

    public TimeOnly? TiempoEstimado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
