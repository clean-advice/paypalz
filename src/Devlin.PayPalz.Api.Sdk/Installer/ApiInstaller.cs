using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Apizr;
using Polly;
using Polly.Extensions.Http;
using Polly.Registry;

namespace Devlin.PayPalz.Api.Sdk.Installer;

public class ApiInstaller
{
    public void InstallPayPalzApi(IServiceCollection services, IConfiguration configuration)
    {
        var registry = new PolicyRegistry
        {
            {
                "TransientHttpError",
                HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromMilliseconds(500),
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2)
                })
            }
        };
        services.AddPolicyRegistry(registry);

        // Apizr registration
        services.AddApizrManagerFor(typeof(ApiInstaller));
    }
}
