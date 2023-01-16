namespace MinicoreCompras.Models
{
    public class ReporteCompras
    {
        public List<Contratos> ListaContratos { get; set; }

        public ReporteCompras()
        {
            ListaContratos = new List<Contratos>();
        }
    }
    public class Contratos
    {
        public string NombreCliente { get; set; }
        public int MontoTotal { get; set; }
    }
}
