using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class MetodoPagoCliente
{
    public int IdMetodoPago { get; set; }

    public int IdCliente { get; set; }

    public int? IdTipoPago { get; set; }

    public string? NombreProveedor { get; set; }

    public string? Cuenta { get; set; }

    public DateTime? FechaExpira { get; set; }

    public bool? PorDefecto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
