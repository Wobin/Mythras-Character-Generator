using Blazored.LocalStorage;
using BlazorState;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddBlazoredLocalStorage()
                .AddScoped<TooltipService>()
                .AddScoped<NotificationService>();

            ConfigureServices(builder.Services);
            await builder.Build().RunAsync();
        }

        public static void ConfigureServices(IServiceCollection aServiceCollection)
        {
            aServiceCollection.AddBlazorState
            (
              (aOptions) => { 
                    aOptions.UseReduxDevToolsBehavior = true;
                    aOptions.Assemblies = new Assembly[] { typeof(Program).GetTypeInfo().Assembly, };
                }
            );
        }
    }
}
