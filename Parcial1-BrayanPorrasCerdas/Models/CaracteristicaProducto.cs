using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class CaracteristicaProducto
{
    public int IdCaracteristica { get; set; }

    public int IdCategoriaProducto { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual CategoriaProducto IdCategoriaProductoNavigation { get; set; } = null!;

    public virtual ICollection<OpcionCaracteristicaProducto> OpcionCaracteristicaProductos { get; set; } = new List<OpcionCaracteristicaProducto>();
}
