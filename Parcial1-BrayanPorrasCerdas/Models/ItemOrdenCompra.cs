using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class ItemOrdenCompra
{
    public int IdItemOrden { get; set; }

    public int IdItemProducto { get; set; }

    public int IdOrdenCompra { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ItemProducto IdItemProductoNavigation { get; set; } = null!;

    public virtual OrdenCompra IdOrdenCompraNavigation { get; set; } = null!;
}
