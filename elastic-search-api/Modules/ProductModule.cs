using Carter;
using elastic_search_api.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace elastic_search_api.Modules;

public class ProductModule : ICarterModule
{
    private readonly IProducts _products;

    public ProductModule(IProducts products)
    {
        _products = products;
    }  
    
    public void AddRoutes(
        IEndpointRouteBuilder app)
    {     
        app.MapGet("/api/products", GetProduct).WithName("Product");
    }

    private Task GetProduct()
    {
        return _products.GetProducts();

    }
}