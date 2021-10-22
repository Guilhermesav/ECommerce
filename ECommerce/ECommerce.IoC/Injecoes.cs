using ECommerce.Blob;
using ECommerce.Data;
using ECommerce.Data.UoW;
using ECommerce.Model.Interfaces;
using ECommerce.Model.Interfaces.Blob;
using ECommerce.Model.Interfaces.Repositorios;
using ECommerce.Model.Interfaces.Services;
using ECommerce.Model.Interfaces.UnitOfWork;
using ECommerce.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ECommerce.IoC
{
    public static class Injecoes
    {
        public static void LoginInjection(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<ECommerceContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ECommerceContext")));
        }

        public static void InterfaceInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ICompraRepositorio, CompraRepositorio>();
            services.AddScoped<ICompraService, CompraService>();
            services.AddTransient<IBlobService, BlobService>(provider =>
                new BlobService(configuration.GetConnectionString("ecommerceinfnetblob")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
