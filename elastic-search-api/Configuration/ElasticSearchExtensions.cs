using Nest;
using elastic_search_api.Models;

namespace elastic_search_api.Configuration;

public static class ElasticSearchExtensions
{
    public static void AddElasticSearch(this IServiceCollection services,
         IConfiguration configuration)
    {
        var url = configuration["ElasticSearch:Url"];
        var defaultIndex = configuration["ElasticSearch:DefaultIndex"];

        var settings =
            new ConnectionSettings(new Uri(url)).DefaultIndex(defaultIndex);
        
        var client = new ElasticClient(settings);
        services.AddSingleton<IElasticClient>(client);

        CreateIndex(client, defaultIndex);
    }

    private static void CreateIndex(
        ElasticClient client, 
        string defaultIndex)
    {
        client.Indices.Create(
            defaultIndex, 
            z => z.Map<Product>(x => x.AutoMap()));
    }
}