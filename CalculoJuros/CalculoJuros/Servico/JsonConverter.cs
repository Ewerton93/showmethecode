using Newtonsoft.Json;

namespace CalculoJuros.Servico
{
    public static class JsonConverter
    {
        public static Destino Deserializar<Destino>(string value)
        {
            var objeto = JsonConvert.DeserializeObject<Destino>(value);

            return objeto;
        }
    }
}
