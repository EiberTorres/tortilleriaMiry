using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Egreso> Egresos { get; set; } = new List<Egreso>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
