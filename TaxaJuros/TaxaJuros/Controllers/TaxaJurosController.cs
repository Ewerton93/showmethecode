using Microsoft.AspNetCore.Mvc;
using TaxaJuros.Servicos;

namespace TaxaJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosServico _taxaJurosServico;

        public TaxaJurosController(ITaxaJurosServico taxaJurosServico)
        {
            _taxaJurosServico = taxaJurosServico;
        }

        private const decimal taxa = 0.01M;

        [HttpGet]
        public decimal Get() => _taxaJurosServico.ObterTaxaJuros();

    }
}
