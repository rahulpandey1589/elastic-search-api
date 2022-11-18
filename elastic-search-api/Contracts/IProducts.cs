using elastic_search_api.Models;

namespace elastic_search_api.Contracts;

public interface IProducts
{
    Task<IEnumerable<Product>> GetProducts();
}