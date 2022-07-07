using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NhaTraining.Repository.Context;
using NhaTraining.Repository.Data;
using NhaTraining.Repository.Repositories.Base;
using NhaTraining.Repository.Repositories.Base.Impl;
using NhaTraining.Service.Services;
using NhaTraining.Service.Services.Base;
using NhaTraining.Service.Services.Base.Impl;
using NhaTraining.Service.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhaTraining
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //services.AddSingleton<typeof(IBaseRepository<>)>(InitializeCosmosClientInstanceAsync(Configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
            IConfigurationSection configSection = Configuration.GetSection("CosmosDb");

            //services.AddDbContext<TrainingContext>(options =>
            //{
            //    options.UseCosmos(configSection["Account"], configSection["Key"], configSection["DatabaseName"]);
            //});



            //services.AddDbContext<TrainingContext>(options =>
            //    options.UseCosmos("Account",
            //    "Key",
            //    "DatabaseName")
            //);
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IBlogService, BlogService>();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NhaTraining", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //using var scope = app.ApplicationServices?.GetService<IServiceScopeFactory>()?.CreateScope();
                //var context = scope?.ServiceProvider.GetRequiredService<TrainingContext>();
                //var result = context!.Database.EnsureCreatedAsync();

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NhaTraining v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private static async Task<Container> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        //{
        //    string databaseName = configurationSection.GetSection("DatabaseName").Value;
        //    string containerName = configurationSection.GetSection("ContainerName").Value;
        //    string account = configurationSection.GetSection("Account").Value;
        //    string key = configurationSection.GetSection("Key").Value;
        //    CosmosClient client = new CosmosClient(account, key);
        //    Container cosmosDb = client.GetContainer( databaseName, containerName);
        //    //BaseRepository<Blog> a = new BaseRepository<Blog>(client, databaseName, containerName);

        //    DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
        //    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

        //    return cosmosDb;
        //}
    }
}
