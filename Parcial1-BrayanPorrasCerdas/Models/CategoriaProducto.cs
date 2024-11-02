using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class CategoriaProducto
{
    public int IdCategoria { get; set; }

    public int? IdCategoriaPadre { get; set; }

    public string? NombreCategoria { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<CaracteristicaProducto> CaracteristicaProductos { get; set; } = new List<CaracteristicaProducto>();

    public virtual CategoriaProducto? IdCategoriaPadreNavigation { get; set; }

    public virtual ICollection<CategoriaProducto> InverseIdCategoriaPadreNavigation { get; set; } = new List<CategoriaProducto>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
