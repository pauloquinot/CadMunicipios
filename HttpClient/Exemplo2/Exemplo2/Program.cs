using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = AcessaCidades();
            Console.Read();
        }
        public static async Task<string> AcessaCidades()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("https://fit.faccat.br/~rodjle/phpws/api/municipios");
            if (response.IsSuccessStatusCode)
            {
                String s = await response.Content.ReadAsStringAsync();
                List<Municipio> lista = JsonConvert.DeserializeObject<List<Municipio>>(s);
                foreach (var item in lista)
                {
                    if (item != null)
                    {
                        Console.WriteLine("Código: {0} - Nome: {1} - UF: {2}", item.CODIGO,item.DESCRICAO,item.UF);
                    }
                }
            }
            string urlContents = "";
            return urlContents;
        }
    }
}
