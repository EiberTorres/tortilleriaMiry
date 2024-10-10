using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Egreso
{
    public int IdEgreso { get; set; }

    public string Concepto { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateTime? FechaEgreso { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Notas { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
