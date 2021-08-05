using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Website.Functions;
using Website.Shared;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Website.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            
        }
    }
}