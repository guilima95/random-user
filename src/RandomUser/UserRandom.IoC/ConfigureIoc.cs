using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using UserRandom.Application.UseCases;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Data.ExternalServices;
using UserRandom.Data.ExternalServices.Contracts;
using UserRandom.Data.ExternalServices.HttpClients;
using UserRandom.Data.MongoDb;
using UserRandom.Data.MongoDb.Contracts;
using UserRandom.Data.Repositories;
using UserRandom.Domain.Notification;
using UserRandom.Domain.Notification.Contracts;
using UserRandom.Domain.Repositories;

namespace UserRandom.IoC
{
    public class ConfigureIoc
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration configuration;
        public ConfigureIoc(IServiceCollection services, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.services = services;
        }

        public void InjectorDependency()
        {
            DateBase();
            DomainServices();
            AppServices();
            HttpClientes();
            Repositories();
        }

        public void DateBase()
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.Port = Convert.ToInt32(configuration.GetSection("MongoDbSettings:Port").Value);
                options.Host = configuration.GetSection("MongoDbSettings:Host").Value;
                options.DatabaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;
                options.User = configuration.GetSection("MongoDbSettings:User").Value;
                options.Password = configuration.GetSection("MongoDbSettings:Password").Value;

            });

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }

        public void AppServices()
        {
            services.AddScoped<IAddUser, AddUser>();
            services.AddScoped<IUpdateUser, UpdateUser>();
            services.AddScoped<IDeleteUser, DeleteUser>();
            services.AddScoped<IGetUser, GetUser>();

        }

        public void DomainServices()
        {

            services.AddScoped<INotifierService, NotifierService>();
            services.AddScoped<INotifier, Notifier>();

        }

        public void Repositories()
        {
            services.AddScoped<IRandomRepository, RandomRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public void HttpClientes()
        {
            services.AddScoped(x => new RandomUserHttpClient());
        }

    }
}



