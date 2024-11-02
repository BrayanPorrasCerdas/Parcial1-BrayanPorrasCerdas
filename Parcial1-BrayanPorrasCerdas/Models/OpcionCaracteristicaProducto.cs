using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class OpcionCaracteristicaProducto
{
    public int IdOpcionCaracteristica { get; set; }

    public int IdCaracteristicaProducto { get; set; }

    public string? Valor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual CaracteristicaProducto IdCaracteristicaProductoNavigation { get; set; } = null!;
}
