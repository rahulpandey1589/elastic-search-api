using elastic_search_api.Contracts;
using elastic_search_api.Implementation;

namespace elastic_search_api.Configuration;

public static  class DependencyRegistration
{
    public static WebApplicationBuilder RegisterServices(
        this WebApplicationBuilder builder
    )
    {
        builder.Services.AddTransient<IProducts, Products>();
        return builder;
    }
}