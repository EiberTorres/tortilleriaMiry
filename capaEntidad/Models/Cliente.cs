using System;
using System.Collections.Generic;

namespace capaEntidad.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string TipoCliente { get; set; } = null!;

    public string NombreCliente { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Rutascliente> Rutasclientes { get; set; } = new List<Rutascliente>();
}
