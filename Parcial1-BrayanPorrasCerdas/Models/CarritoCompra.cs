using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class CarritoCompra
{
    public int IdCarrito { get; set; }

    public int IdCliente { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ItemCarritoCompra> ItemCarritoCompras { get; set; } = new List<ItemCarritoCompra>();
}
