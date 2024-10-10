using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Clasesproducto
{
    public int IdClaseProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
