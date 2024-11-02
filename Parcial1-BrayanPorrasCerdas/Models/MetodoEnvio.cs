using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class MetodoEnvio
{
    public int IdMetodoEnvio { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
