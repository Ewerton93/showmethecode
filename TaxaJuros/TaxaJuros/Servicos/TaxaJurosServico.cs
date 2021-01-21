using System;

namespace TaxaJuros.Servicos
{
    public class TaxaJurosServico : ITaxaJurosServico
    {
        public TaxaJurosServico()
        {

        }

        public decimal ObterTaxaJuros()
        {
            return 0.01M;
        }
    }
}
