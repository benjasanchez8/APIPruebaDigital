using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public int? Telefono { get; set; }

    public string? Correo { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
