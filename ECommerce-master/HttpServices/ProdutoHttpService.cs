using ECommerce.Model;
using ECommerce.Model.Interfaces;
using ECommerce.Model.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.HttpServices
{
    public class ProdutoHttpService : IProdutoService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptionsMonitor<HttpOptions> _httpOptions;
      

        public ProdutoHttpService(IHttpClientFactory httpClientFactory, IOptionsMonitor<HttpOptions> httpOptions)
        {
            
            _httpOptions = httpOptions;

            _httpClient = httpClientFactory.CreateClient(httpOptions.CurrentValue.Name);
            _httpClient.Timeout = TimeSpan.FromMinutes(_httpOptions.CurrentValue.Timeout);
        }
        public async Task Create(ProdutoModel produtoCriado)
        {
            var path = $"{_httpOptions.CurrentValue.ProdutoPath}";

            var httpContent = new StringContent(JsonConvert.SerializeObject(produtoCriado), Encoding.UTF8, "application/json");

            var httpResponseMessage = await _httpClient.PostAsync(path, httpContent);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {

            }
        }

        public async Task Delete(int id,string uri)
        {
            var pathWithId = $"{_httpOptions.CurrentValue.ProdutoPath}/{id}";

            var result = await _httpClient.DeleteAsync(pathWithId);

            if (!result.IsSuccessStatusCode)
            {

            }
        }

        public async Task<IEnumerable<ProdutoModel>> GetAll()
        {

            var path = $"{_httpOptions.CurrentValue.ProdutoPath}";            
            var result = await _httpClient.GetStringAsync(path);
           
            return JsonConvert.DeserializeObject<IEnumerable<ProdutoModel>>(result);
        }

        public async Task<ProdutoModel> GetDetails(int id)
        {
            var pathWithId = $"{_httpOptions.CurrentValue.ProdutoPath}/ById/{id}";

            var result = await _httpClient.GetStringAsync(pathWithId);

            return JsonConvert.DeserializeObject<ProdutoModel>(result);
        }

        public async Task Update(ProdutoModel produtoAtualizado)
        {
            var path = $"{_httpOptions.CurrentValue.ProdutoPath}";

            var httpContent = new StringContent(JsonConvert.SerializeObject(produtoAtualizado), Encoding.UTF8, "application/json");

            var httpResponseMessage = await _httpClient.PutAsync(path, httpContent);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {

            }
        }
    }
}
