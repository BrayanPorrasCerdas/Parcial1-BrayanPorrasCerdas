using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class ItemProducto
{
    public int IdItemProducto { get; set; }

    public int IdProducto { get; set; }

    public string? CodigoBarras { get; set; }

    public int? CantidadDisponible { get; set; }

    public string? UrlImagen { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual ICollection<ItemOrdenCompra> ItemOrdenCompras { get; set; } = new List<ItemOrdenCompra>();
}
