using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace myProject
{
    public class Startup
    {

        //UnComment the below lines if you wish to use the Azure App Configuration

        //#region Global variables for keys of App Configuration

        //public static string appConfig_Key1;
        //public static string appConfig_Key2;

        //#endregion     

        //--------------------------------------------------------------------------

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();

            //UnComment the below lines if you wish to use the Azure App Configuration

            //#region Fetch and initialize the actual values corresponding to the respective keys

            //appConfig_Key1 = Configuration.GetSection(AppConfigUtil.key1).Value;
            //appConfig_Key2 = Configuration.GetSection(AppConfigUtil.key2).Value;

            //#endregion

            //services.Configure<AppConfigUtil>(Configuration.GetSection("AppConfigUtil"));

            //--------------------------------------------------------------------------

            ConfigureSwagger(services);

        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Write Your Project Name Here", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UsePathBase("/azure_swagger_dotnet");//Specify your endpoint here

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/azure_swagger_dotnet/swagger/v1/swagger.json", "Azure Swagger DotNet APIs");
            });
            ///app.UseAzureAppConfiguration();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();            

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapControllers();                
            });

        }

    }
}
