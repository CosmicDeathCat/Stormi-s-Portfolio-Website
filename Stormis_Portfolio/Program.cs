using Azure.Communication.Email;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Stormis_Portfolio.Services;

namespace Stormis_Portfolio;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddSingleton<EmailClient>(sp =>
        {
            var emailSettings = builder.Configuration.GetSection("EmailSettings");
            var endpoint = emailSettings["ConnectionString"];
            var connectionString = endpoint;
            return new EmailClient(connectionString);
        });
        builder.Services.AddTransient<IEmailService, EmailService>();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }
}