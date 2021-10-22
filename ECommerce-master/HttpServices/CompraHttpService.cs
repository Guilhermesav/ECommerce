using ECommerce.Model;
using ECommerce.Model.Interfaces.Services;
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
    public class CompraHttpService : ICompraService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptionsMonitor<HttpOptions> _httpOptions;
       

        public CompraHttpService(IHttpClientFactory httpClientFactory, IOptionsMonitor<HttpOptions> httpOptions)
        {
            
            _httpOptions = httpOptions;

            _httpClient = httpClientFactory.CreateClient(httpOptions.CurrentValue.Name);
            _httpClient.Timeout = TimeSpan.FromMinutes(_httpOptions.CurrentValue.Timeout);
        }
        public async Task Create(CompraModel compraFeita)
        {
            var path = $"{_httpOptions.CurrentValue.CompraPath}";

            var httpContent = new StringContent(JsonConvert.SerializeObject(compraFeita), Encoding.UTF8, "application/json");

            var httpResponseMessage = await _httpClient.PostAsync(path, httpContent);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {

            }
        }

        public async Task<IEnumerable<CompraModel>> GetAll()
        {
            var path = $"{_httpOptions.CurrentValue.CompraPath}";
            var result = await _httpClient.GetStringAsync(path);

            return JsonConvert.DeserializeObject<IEnumerable<CompraModel>>(result);
        }

        public async Task<IEnumerable<CompraModel>> GetCompraByUser(string usuario)
        {
            var path = $"{_httpOptions.CurrentValue.CompraPath}/{usuario}";
            var result = await _httpClient.GetStringAsync(path) ;

            return JsonConvert.DeserializeObject<IEnumerable<CompraModel>>(result);
        }

        public async Task<CompraModel> GetDetails(int id)
        {
            var pathWithId = $"{_httpOptions.CurrentValue.CompraPath}/ById/{id}";

            var result = await _httpClient.GetStringAsync(pathWithId);

            return JsonConvert.DeserializeObject<CompraModel>(result);
        }
    }
}
