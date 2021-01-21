using CalculoJuros.Dominio;
using CalculoJuros.Servico.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Servico
{
    public class CalcularJurosServico : ICalcularJurosServico
    {
        private readonly ITaxaJurosServico _taxaJurosServico;

        public  Juros _juros { get; set; }

        public CalcularJurosServico(ITaxaJurosServico taxaJurosServico)
        {
            _taxaJurosServico = taxaJurosServico;
        }

        public async Task<string> CalcularJuros(double valorInicial, int numeroMeses)
        {
            try
            {
                var taxaJuros = await _taxaJurosServico.ObterTaxaJuros();

                _juros = new Juros(valorInicial, numeroMeses, taxaJuros);

                return _juros.Calcular();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

    }
}
