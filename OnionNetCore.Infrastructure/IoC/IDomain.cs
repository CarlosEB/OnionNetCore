using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnionNetCore.Infrastructure.IoC
{
    public interface IDomain
    {
        Domain Initiate(IServiceCollection services, IConfiguration configuration);

        void Load();

        IServiceProvider GetServiceProvider();
    }
}