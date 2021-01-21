using CalculoJuros.Dominio;
using CalculoJuros.Servico;
using CalculoJuros.Servico.Interface;
using FluentAssertions;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalculoJuros.Teste.Integracao
{
    public class JurosSpec
    {
        [Fact]
        public async Task DeveMockarTaxaJurosECalcularJuros()
        {
            var _taxaJurosServico = Substitute.For<ITaxaJurosServico>();
            var _calcularJurosServico = new CalcularJurosServico(_taxaJurosServico);

            double valorinicial = 100;
            int meses = 5;
            double taxa = 0.01;
            var resultadoEsperado = "105,10";          

            _taxaJurosServico.ObterTaxaJuros().Returns(taxa);

            var jurosCalculado = await _calcularJurosServico.CalcularJuros(valorinicial, meses);

            jurosCalculado.Should().NotBeNull();
            _calcularJurosServico._juros.Meses.Should().Be(meses);
            _calcularJurosServico._juros.Valor.Should().Be(valorinicial);
            _calcularJurosServico._juros.Taxa.Should().Be(taxa);
            jurosCalculado.Should().Be(resultadoEsperado);
        }
    }

}