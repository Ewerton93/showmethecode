using CalculoJuros.Dominio;
using Xunit;
using FluentAssertions;
using System;

namespace CalculoJuros.Teste.Unitario
{
    public class JurosSpec
    {

        [Fact]
        public void DeveCriarUmaInstanciaDeJurosValido()
        {
            double valorinicial = 100;
            int meses = 5;
            double taxa = 0.10;

            var juros = new Juros(valorinicial, meses, taxa);

            juros.Should().NotBeNull();
            juros.Valor.Should().Be(valorinicial);
            juros.Meses.Should().Be(meses);
            juros.Taxa.Should().Be(taxa);
            juros.Valido.Should().BeTrue();
        }

        [Fact]
        public void DeveInstanciarJurosComArgumentoExceptionComValorNegativo()
        {
            double valorinicial = -110;
            int meses = 0;
            double taxa = 0.10;

            Action juros = () => new Juros(valorinicial, meses, taxa);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>("valor", juros);
            Assert.Contains("O valor inicial não pode ser menor ou igual a zero", exception.Message);
        }

        [Fact]
        public void DeveInstanciarJurosComArgumentoExceptionComValorIgualZero()
        {
            double valorinicial = 0;
            int meses = 0;
            double taxa = 0.10;

            Action juros = () => new Juros(valorinicial, meses, taxa);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>("valor", juros);            
            Assert.Contains("O valor inicial não pode ser menor ou igual a zero", exception.Message);
        }

        [Fact]
        public void DeveInstanciarJurosComArgumentoExceptionComMesesNegativo()
        {
            double valorinicial = 100;
            int meses = -1;
            double taxa = 0.10;

            Action juros = () => new Juros(valorinicial, meses, taxa);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>("meses", juros);
            Assert.Contains("A quantidade de meses não pode ser menor ou igual a zero", exception.Message);
        }

        [Fact]
        public void DeveInstanciarJurosComArgumentoExceptionComMesesIgualZero()
        {
            double valorinicial = 100;
            int meses = 0;
            double taxa = 0.10;

            Action juros = () => new Juros(valorinicial, meses, taxa);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>("meses", juros);
            Assert.Contains("A quantidade de meses não pode ser menor ou igual a zero", exception.Message);
        }

        [Fact]
        public void DeveInstanciarJurosComArgumentoExceptionComTaxaNegativo()
        {
            double valorinicial = 100;
            int meses = 5;
            double taxa = -1;

            Action juros = () => new Juros(valorinicial, meses, taxa);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>("taxa", juros);
            Assert.Contains("A taxa de juros informada deve ser menor ou igual a zero", exception.Message);
        }

        [Fact]
        public void DeveInstanciarJurosComArgumentoExceptionComTaxaIgualZero()
        {
            double valorinicial = 100;
            int meses = 5;
            double taxa = 0;

            Action juros = () => new Juros(valorinicial, meses, taxa);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>("taxa", juros);
            Assert.Contains("A taxa de juros informada deve ser menor ou igual a zero", exception.Message);
        }

    }
}