using apiDesafioTecnico.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace apiDesafioTecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositorioController : ControllerBase
    {
        [HttpGet]
        public async Task<dynamic> RecuperarRepositorio()
        {
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("User-Agent", "request");
            //cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            cliente.BaseAddress = new Uri("https://api.github.com/orgs/takenet/repos");

            //Realizando a requisição na API do Github
            HttpResponseMessage resposta = await cliente.GetAsync("https://api.github.com/orgs/takenet/repos");            

            //Convertendo o retorno da requisição em String
            string respostaString = await resposta.Content.ReadAsStringAsync();

            // Convertendo a string em uma Lista de Repositorios
            var respArray = JsonConvert.DeserializeObject<List<Repositorio>>(respostaString.ToString());


            // Filtrando dados
            List<Repositorio> newRepos = new List<Repositorio>();

            int tamanhoLista = respArray.Count;


            for (int i = 0; i < 6; i++)
            {
                //filtrando elementos da linguagem C# e adicionando o elemento na nova lista
                if(respArray[i].language == "C#")
                {                    
                    newRepos.Add(respArray[i]);                    
                }
            }

            //Inserindo os dados dentro de uma estrutura chave, valor
            IDictionary<int, string> dic1 = new Dictionary<int, string>();
            dic1.Add(1, newRepos[0].name);
            dic1.Add(2, newRepos[0].description);
            dic1.Add(3, newRepos[1].name);
            dic1.Add(4, newRepos[1].description);
            dic1.Add(5, newRepos[2].name);
            dic1.Add(6, newRepos[2].description);
            dic1.Add(7, newRepos[3].name);
            dic1.Add(8, newRepos[3].description);
            dic1.Add(9, newRepos[4].name);
            dic1.Add(10, newRepos[4].description);

            return dic1;

        }

    }
}
