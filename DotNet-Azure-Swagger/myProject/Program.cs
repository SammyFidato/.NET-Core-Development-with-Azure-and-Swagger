using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace myProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
         
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();//Comment this if you uncomment the below

                    //UnComment the below lines if you wish to use the Azure App Configuration

                    //webBuilder.ConfigureAppConfiguration((context, config) =>
                    //{
                    //    var settings = config.Build();
                    //    config.AddAzureAppConfiguration(options =>
                    //    {
                    //        options.Connect(Environment.GetEnvironmentVariable("AppConfigConnection")).ConfigureRefresh(
                    //            refresh => { refresh.Register("refreshversion", true); })
                    //        .UseFeatureFlags();
                    //    });
                    //})
                    //.UseStartup<Startup>();

                    //-------------------------------------------------------------------------=
                });

    }
}
