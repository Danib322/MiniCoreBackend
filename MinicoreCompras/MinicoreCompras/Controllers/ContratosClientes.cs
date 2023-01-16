using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinicoreCompras.Models;

namespace MinicoreCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosClientes : ControllerBase
    {
        private readonly MiniCoreComprasContext _context;

        public ContratosClientes(MiniCoreComprasContext context)
        {
            _context = context;
        }
        // GET: Minicorecompras
        [HttpGet(Name = "~/GetReportecompras")]
        public async Task<ReporteCompras> GetReportecompras(DateTime FechaInicio, DateTime FechaFin)
        {


            var contexto = (from cr in _context.Contratos.Where(cr => cr.FechaContrato >= FechaInicio && cr.FechaContrato <= FechaFin)
                            join cl in _context.Clientes on cr.IdCliente equals cl.IdCliente
                            select new
                            {
                                idCliente = cr.IdCliente,
                                NombreCliente = cl.NombreCliente,
                                MontoCliente = cr.Monto,
                            }).ToList();


            var listaClientes = contexto.Select(r => r.idCliente).Distinct().ToList();
            var modelo = new ReporteCompras();

            foreach (var obj in listaClientes)
            {
                var contrato = new Contratos();
                var ContratosCliente = contexto.Where(c => c.idCliente == obj).ToList();
                contrato.NombreCliente = contexto.Where(c => c.idCliente == obj).Select(n => n.NombreCliente).FirstOrDefault();
                foreach (var monto in ContratosCliente)
                {
                    contrato.MontoTotal += monto.MontoCliente;
                }

                modelo.ListaContratos.Add(contrato);
            }

            return modelo;

        }
    }
}
