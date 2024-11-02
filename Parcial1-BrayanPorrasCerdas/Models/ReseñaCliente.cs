using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class ReseñaCliente
{
    public int IdResena { get; set; }

    public int IdCliente { get; set; }

    public int IdProducto { get; set; }

    public int? ValorCalificacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
