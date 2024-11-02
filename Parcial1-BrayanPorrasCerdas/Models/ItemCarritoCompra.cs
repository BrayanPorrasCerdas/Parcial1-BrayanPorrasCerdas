using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class ItemCarritoCompra
{
    public int IdItemCarrito { get; set; }

    public int IdCarrito { get; set; }

    public int? IdItemProducto { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual CarritoCompra IdCarritoNavigation { get; set; } = null!;
}
