using System;
using System.Collections.Generic;

namespace MinicoreCompras.Models;

public partial class Contrato
{
    public int IdContrato { get; set; }

    public int IdCliente { get; set; }

    public string Contratos { get; set; } = null!;

    public int Monto { get; set; }

    public DateTime FechaContrato { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
