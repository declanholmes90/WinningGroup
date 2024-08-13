using MongoDB.Driver;
using WinningGroup.Infrastructure.Entities;

namespace WinningGroup.Infrastructure.Repositories
{
    public interface IProductsRepository
    {
        Task<IList<Product>> GetProducts(FilterDefinition<Product> filter);
    }

    public class ProductsRepository : IProductsRepository
    {
        private IMongoCollection<Product> productsCollection;
        public ProductsRepository(IProductsDBConnection dbConnection)
        {
            productsCollection = dbConnection.GetProductsCollection();
        }

        public async Task<IList<Product>> GetProducts(FilterDefinition<Product> filter)
        {
            return (await productsCollection.FindAsync(filter)).ToList();
        }
    }
}
