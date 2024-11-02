using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class Direccion
{
    public int Id { get; set; }

    public int? ProvinciaId { get; set; }

    public int? CantonId { get; set; }

    public int? DistritoId { get; set; }

    public string DireccionExacta { get; set; } = null!;

    public string? CodigoPostal { get; set; }

    public int? IdPais { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
