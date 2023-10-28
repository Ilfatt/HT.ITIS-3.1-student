using Dotnet.Homeworks.Data.DatabaseContext;
using Dotnet.Homeworks.Domain.Abstractions.Repositories;
using Dotnet.Homeworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Homeworks.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Products.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task DeleteProductByGuidAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
                          .FirstOrDefaultAsync(x => x.Id == id,
                              cancellationToken: cancellationToken)
                      ?? throw new ArgumentException("Product not found");

        _dbContext.Remove(product);
    }

    public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        var productFromDb = await _dbContext.Products
                                .FirstOrDefaultAsync(x => x.Id == product.Id,
                                    cancellationToken: cancellationToken)
                            ?? throw new ArgumentException("Product not found");

        productFromDb.Name = product.Name;
    }

    public Task<Guid> InsertProductAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Add(product);
        return Task.FromResult(product.Id);
    }
}