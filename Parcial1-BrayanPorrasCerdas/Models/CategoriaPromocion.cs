using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class CategoriaPromocion
{
    public int IdCategoria { get; set; }

    public int IdPromocion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Promocion IdPromocionNavigation { get; set; } = null!;
}
