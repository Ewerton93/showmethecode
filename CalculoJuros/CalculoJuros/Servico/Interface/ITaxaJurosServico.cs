using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Servico.Interface
{
    public interface ITaxaJurosServico
    {
        Task<double> ObterTaxaJuros();
    }
}
