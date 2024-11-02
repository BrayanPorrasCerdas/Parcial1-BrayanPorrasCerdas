using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class ConfiguracionProducto
{
    public int IdItemProducto { get; set; }

    public int IdOpcionCaracteristicaProducto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ItemProducto IdItemProductoNavigation { get; set; } = null!;

    public virtual OpcionCaracteristicaProducto IdOpcionCaracteristicaProductoNavigation { get; set; } = null!;
}
