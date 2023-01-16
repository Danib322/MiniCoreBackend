using System;
using System.Collections.Generic;

namespace MinicoreCompras.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; } = new List<Contrato>();
}
