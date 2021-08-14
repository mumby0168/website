using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Octokit;
using Website.Functions;
using Website.Shared;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Website.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddCosmosRepository(options =>
            {
                options.DatabaseId = "blog-db";
                options.ContainerPerItemType = true;
                options.CosmosConnectionString = Environment.GetEnvironmentVariable("DatabaseConnectionString");
            });

            builder.Services.AddScoped(provider => new GitHubClient(new ProductHeaderValue("billy-mumby-blog-api")));
        }
    }
}