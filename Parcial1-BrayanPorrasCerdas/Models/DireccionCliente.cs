using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class DireccionCliente
{
    public int IdCliente { get; set; }

    public int IdDireccion { get; set; }

    public bool? PorDefecto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Direccion IdDireccionNavigation { get; set; } = null!;
}
