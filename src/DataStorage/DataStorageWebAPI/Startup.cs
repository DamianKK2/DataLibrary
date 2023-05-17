using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Command.Factory.Impl;
using DataStorageLibrary.ResultMapper;
using DataStorageLibrary.ResultMapper.Impl;
using DataStorageLibrary.Action;
using DataStorageLibrary.Action.Impl;
using DataStorageLibrary.ConnectionProvider;
using DataStorageLibrary.ConnectionProvider.Impl;
using DataStorageLibrary.Storages;
using DataStorageLibrary.Storages.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using DataStorageLibrary.Storages.Factory;
using DataStorageLibrary.Storages.Factory.Impl;
using Microsoft.Extensions.Configuration;
using DataStorageLibrary.Data;
using DataStorageLibrary.ResultMappers;
using DataLibrary.Formatter;
using DataLibrary.Formatters;
using DataStorageLibrary.Formatters;

namespace DataStorageLibrary
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            configuration = builder.Build();
        }
            public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConnectionProvider>(ctx => new PgConnectionProvider(configuration.GetConnectionString("con")));
            services.AddSingleton<IStorageFactory<IBookStorage, Book>,BookStorageFactory>();
            services.AddSingleton(ctx => ctx.GetRequiredService<IStorageFactory<IBookStorage, Book>>().Create());
            services.AddSingleton<IFormatter<Book>, BookMetadataFormatter>();
            services.AddSingleton<IFormatter<ContentIndex>, ContentIndexFormatter>();
            services.AddRazorPages();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=books}/{action=id}");
            });
        }
    }
}
