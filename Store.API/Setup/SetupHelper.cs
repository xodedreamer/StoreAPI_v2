using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Store.API.Settings;
using Store.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Store.API.Setup
{
    public static class SetupHelper
    {
        private static string ApiTitle = "Store API";
        private static string ApiDocumentationName = "Store";

        public static IServiceCollection AddScopedByBaseType(this IServiceCollection services, Type baseType)
        {
            Assembly
                .GetAssembly(baseType)
                .GetTypesOf(baseType)
                .ForEach(type => services.AddScoped(type.GetInterface($"I{type.Name}"), type));

            return services;
        }

        public static IServiceCollection AddScopedHandlers(this IServiceCollection services, Type handlerType, Assembly assembly)
        {
            assembly
                .GetTypes()
                .ToList()
                .ForEach(type =>
                    type
                        .GetInterfaces()
                        .Where(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == handlerType)
                        .ToList()
                        .ForEach(@interface => services.AddScoped(@interface, type))
                );

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ApiTitle, Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection AddSqlServerContexts(this IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<MainDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(settings.ConnectionStrings.MainDbConnection)
            );

            services.AddDbContext<EventStoreSQLContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(settings.ConnectionStrings.MainDbConnection)
            );

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            return services;
        }



        public static IApplicationBuilder UseSawaggerWithDocs(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiDocumentationName);
            });

            return app;
        }

        public static IApplicationBuilder UseDatabaseInitialization(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<MainDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<EventStoreSQLContext>().Database.Migrate();
            }

            return app;
        }

        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            return app;
        }

        public static IApplicationBuilder UseDeveloperExceptionPageIfDebug(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            return app;
        }



        public static List<Type> GetTypesOf(this Assembly assembly, Type baseType) => assembly
                .GetTypes()
                .Where(type =>
                    type.BaseType != null
                    &&
                        type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == baseType // -> Generics, ex: CrudRepository<>
                        || baseType.IsAssignableFrom(type) && !type.IsAbstract // -> Non generics, ex: Repository
                    )
                .ToList();
    }
}
