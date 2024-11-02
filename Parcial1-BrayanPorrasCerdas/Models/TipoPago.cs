using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class TipoPago
{
    public int IdTipoPago { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
