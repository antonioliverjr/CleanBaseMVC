using CleanBase.Application.Interfaces;
using CleanBase.Application.Mappings;
using CleanBase.Application.Services;
using CleanBase.Domain.Account;
using CleanBase.Domain.Interfaces;
using CleanBase.Infra.Data.Context;
using CleanBase.Infra.Data.Identity;
using CleanBase.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBase.Infra.IoC
{
    public static class DependecyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureApi(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            // Adicionando dependênciado Identity e Roles
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Adicionando Inversão de Controle do Identity
            services.AddScoped<IAuthenticate, AuthenticateService>();

            // Adicionando Inversão de Controle dos Repositories para Migrations
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Adicionando Inversão de Controle dos Serviços das Entitades
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            // Adicionando classe de mappeamento dos Domain x DTO ou View Models
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // Adicionando Mediator referência para CQRS
            var myHandlers = AppDomain.CurrentDomain.Load("CleanBase.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
