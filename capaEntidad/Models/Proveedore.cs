using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string NombreProveedor { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
