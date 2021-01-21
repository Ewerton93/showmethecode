using CalculoJuros.Servico.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalcularJurosServico _calcularJurosServico;

        public CalculaJurosController(ICalcularJurosServico calcularJurosServico)
        {
            _calcularJurosServico = calcularJurosServico;
        }

        
        [HttpGet]
        public async Task<ActionResult<string>> Get(double valorInicial, int meses)
        {
            var result = await _calcularJurosServico.CalcularJuros(valorInicial, meses);

            return Ok(result);
        }
    }
}
