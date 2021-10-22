using ECommerce.HttpServices;
using ECommerce.Model.Interfaces;
using ECommerce.Model.Interfaces.Services;
using ECommerce.Model.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Extensions
{
    public static class HttpExtensions
    {
        public static void RegisterHttp(this IServiceCollection services, IConfiguration configuration)
        {
            var projetoHttpOptionsSection = configuration.GetSection(nameof(HttpOptions));
            var projetoHttpOptions = projetoHttpOptionsSection.Get<HttpOptions>();

            services.AddHttpClient(projetoHttpOptions.Name, x => { x.BaseAddress = projetoHttpOptions.ApiBaseUrl; });

            services.AddTransient<IProdutoService, ProdutoHttpService>();
            services.AddTransient<ICompraService, CompraHttpService>();

        }
    }
}
