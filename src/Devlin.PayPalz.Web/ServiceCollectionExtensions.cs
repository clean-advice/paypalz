using Devlin.PayPalz.TaxCalculationApi;

namespace Devlin.PayPalz.Web;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddTaxCalculationApiClient(
        this IServiceCollection services, Action<HttpClient> configureClient) =>
            services.AddHttpClient<ITaxCalculationApiClient, TaxCalculationApiClient>(
                httpClient => configureClient(httpClient));
}
