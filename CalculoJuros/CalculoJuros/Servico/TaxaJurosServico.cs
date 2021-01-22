using CalculoJuros.Servico.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculoJuros.Servico
{
    public class TaxaJurosServico : ITaxaJurosServico
    {
        public async Task<double> ObterTaxaJuros()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://taxajuros:80");
                HttpResponseMessage taxa = null;
                try
                {
                    taxa = await client.GetAsync("taxajuros");
                }
                catch
                {
                    throw new HttpRequestException($"A aplicação Taxa de Juros ocorreu um erro ao comunicação. Tente novamente mais tarde.");
                }

                if (!taxa.IsSuccessStatusCode)
                    throw new HttpRequestException($"A aplicação Taxa de Juros está indisponivel no momento e não retornou o valor esperado. Verifique a aplicação {client.BaseAddress} com status de erro: {taxa.StatusCode}");

                return JsonConverter.Deserializar<double>(await taxa.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar a taxa de juros. Erro: {e}");
            }

          
        }
    }
}
