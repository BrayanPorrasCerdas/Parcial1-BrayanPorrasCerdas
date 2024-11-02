using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class OrdenCompra
{
    public int IdOrdenCompra { get; set; }

    public int IdCliente { get; set; }

    public int IdMetodoPago { get; set; }

    public int IdDireccionEnvio { get; set; }

    public int IdMetodoEnvio { get; set; }

    public decimal? MontoOrden { get; set; }

    public int IdEstadoOrden { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ItemOrdenCompra> ItemOrdenCompras { get; set; } = new List<ItemOrdenCompra>();
}
