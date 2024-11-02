using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdCategoriaProducto { get; set; }

    public string? NombreProducto { get; set; }

    public string? Descripcion { get; set; }

    public string? UrlImagen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual CategoriaProducto IdCategoriaProductoNavigation { get; set; } = null!;

    public virtual ICollection<ItemProducto> ItemProductos { get; set; } = new List<ItemProducto>();
}
