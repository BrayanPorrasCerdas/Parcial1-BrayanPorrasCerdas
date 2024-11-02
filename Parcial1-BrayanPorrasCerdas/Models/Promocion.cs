using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class Promocion
{
    public int IdPromocion { get; set; }

    public string? NombreCorto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? PorcentajeDescuento { get; set; }

    public DateTime? FechaInicia { get; set; }

    public DateTime? FechaFinaliza { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<CategoriaPromocion> CategoriaPromocions { get; set; } = new List<CategoriaPromocion>();
}
