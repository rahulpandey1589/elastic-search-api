using Nest;
using elastic_search_api.Contracts;
using elastic_search_api.Models;
                                
namespace elastic_search_api.Implementation;

public class Products : IProducts
{
    private readonly IElasticClient _elasticClient;

    public Products(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }
    
    public async Task<IEnumerable<Product>> GetProducts()
    {
        var queryResponse
            = await _elasticClient.SearchAsync<Product>(
                s => s.Query(
                    q => q.MatchAll()
                ));

       return  queryResponse.Documents.ToList();
    }
}

