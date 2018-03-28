using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionNetCore.Core.Interfaces.Repositories;
using OnionNetCore.Core.Interfaces.Services;
using OnionNetCore.Core.Interfaces.UnitOfWork;
using OnionNetCore.Core.Services;
using OnionNetCore.Infrastructure.DataAccess.Context;
using OnionNetCore.Infrastructure.DataAccess.Repositories;
using OnionNetCore.Infrastructure.DataAccess.UnitOfWork;

namespace OnionNetCore.Infrastructure.IoC
{
    public partial class Domain : IDomain
    {
        private static Domain _instance;
        private IServiceCollection _services;
        private IConfiguration _configuration;

        public static Domain GetInstance => _instance ?? (_instance = new Domain());

        public Domain Initiate(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            return this;
        }

        public void Load()
        {
            ConfigureServices();            
        }

        public IServiceProvider GetServiceProvider()
        {
            return _services.BuildServiceProvider();
        }

        private void ConfigureServices()
        {
            _services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            _services.AddDbContext<DomainContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            _services.AddTransient<IUnitOfWork, UnitOfWork>();

            _services.AddTransient<IUserService, UserService>();

            _services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}