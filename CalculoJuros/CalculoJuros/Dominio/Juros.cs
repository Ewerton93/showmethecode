using System;
using System.Collections.Generic;

namespace CalculoJuros.Dominio
{
    public class Juros
    {
        public double Valor { get; private set; }
        public int Meses { get; private set; }
        public double Taxa { get; private set; }
        public bool Valido { get; private set; }

        public Juros(double valor, int meses, double taxa)
        {
            Valor = valor;
            Meses = meses;
            Taxa = taxa;
            Valido = false;
            Validar();
        }

        public void Validar()
        {
            ValidarValorNegativoOuIgualZero();
            ValidarMesesNegativoOuIgualZero();
            ValidarTaxaNegativoIgualZero();
            Valido = true;
        }

        private void ValidarValorNegativoOuIgualZero()
        { 
            if (Valor <= 0) 
                throw new ArgumentOutOfRangeException("valor", Valor, "O valor inicial não pode ser menor ou igual a zero");
        }

        private void ValidarMesesNegativoOuIgualZero()
        {
            if (Meses <= 0)
                throw new ArgumentOutOfRangeException("meses", Meses, "A quantidade de meses não pode ser menor ou igual a zero");
        }

        private void ValidarTaxaNegativoIgualZero()
        {
            if (Taxa <= 0)
                throw new ArgumentOutOfRangeException("taxa", Taxa, "A taxa de juros informada deve ser menor ou igual a zero");
        }



        public string Calcular()
        {
            double valorCorrigido = Valor * Math.Pow((1 + Taxa), Meses);
            if (double.IsFinite(valorCorrigido) && valorCorrigido <= (double)decimal.MaxValue)
                return string.Format("{0:0.00}", ((Math.Truncate(valorCorrigido * 100) / 100)));
            else
                throw new OverflowException("Erro ao calcular, pois Valor calculado foi maior que o esperado");
        }
       
    }

    
}
