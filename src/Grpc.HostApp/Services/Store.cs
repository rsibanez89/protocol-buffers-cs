using Grpc.Core;

namespace Grpc.HostApp.Services;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
}

public class StoreService : Store.StoreBase
{
    private readonly ILogger<StoreService> _logger;
    private static Product[] _products = [
        new Product { ProductId = 1, Name = "Product 1", Description = "Description 1", Price = 1.99f },
        new Product { ProductId = 2, Name = "Product 2", Description = "Description 2", Price = 2.99f },
        new Product { ProductId = 3, Name = "Product 3", Description = "Description 3", Price = 3.99f },
        new Product { ProductId = 4, Name = "Product 4", Description = "Description 4", Price = 4.99f },
    ];

    public StoreService(ILogger<StoreService> logger)
    {
        _logger = logger;
    }

    public override Task<GetProductResponse> GetProduct(GetProductRequest request, ServerCallContext context)
    {
        var product = _products.First(p => p.ProductId == request.ProductId);
        return Task.FromResult(new GetProductResponse
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        });
    }

    public override Task<GetAllProductsResponse> GetAllProducts(GetAllProductsRequest request, ServerCallContext context)
    {
        var response = new GetAllProductsResponse();
        response.Products.AddRange(_products.Select(p => new GetProductResponse
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }));
        
        return Task.FromResult(response);
    }

    public override Task<GetAllProductsResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
    {
        _products = _products.Where(p => p.ProductId != request.ProductId).ToArray();
        var response = new GetAllProductsResponse();
        response.Products.AddRange(_products.Select(p => new GetProductResponse
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }));
        
        return Task.FromResult(response);
    }
}
