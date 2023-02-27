using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.API.Auth;
using Store.API.Settings;
using Store.API.Setup;
using Store.Bus;
using Store.Domain.Bus;
using Store.Domain.Handlers.Commands;
using Store.Domain.Handlers.Events;
using Store.Domain.Interfaces.Identity;
using Store.Domain.Interfaces.Repositories.Common;
using Store.Repository.Repositories.Common;
using Store.Repository.UoW;

namespace Store.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => AppSettings = configuration.Get<AppSettings>();

        public AppSettings AppSettings { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDistributedMemoryCache()
                .AddSwagger()
                //.AddMediatR()
               // .AddAutoMapper()
                .AddCustomMvc()
                .AddSingleton(AppSettings)
                .AddSqlServerContexts(AppSettings)
                .AddJwtAuth(AppSettings)
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IMediatorHandler, InMemoryBus>()
                .AddScoped<IUser, UserControl>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScopedByBaseType(typeof(CrudRepository<>)) // -> Repositories
                .AddScopedHandlers(typeof(INotificationHandler<>), typeof(UserEventHandler).Assembly) // -> Events
                .AddScopedHandlers(typeof(IRequestHandler<>), typeof(UserCommandHandler).Assembly) // -> Commands
            ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) =>
            app
                .UseDeveloperExceptionPageIfDebug(env)
                .UseHttpsRedirection()
                .UseCustomCors()
                .UseSawaggerWithDocs()
                .UseDatabaseInitialization()
                .UseMvc()
            ;
    }
}
