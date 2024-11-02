using System;
using System.Collections.Generic;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<CarritoCompra> CarritoCompras { get; set; } = new List<CarritoCompra>();

    public virtual ICollection<MetodoPagoCliente> MetodoPagoClientes { get; set; } = new List<MetodoPagoCliente>();

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();

    public virtual ICollection<ReseñaCliente> ReseñaClientes { get; set; } = new List<ReseñaCliente>();
}
