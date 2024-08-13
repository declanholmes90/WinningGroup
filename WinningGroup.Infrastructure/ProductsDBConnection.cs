using MongoDB.Driver;
using WinningGroup.Infrastructure.Entities;

namespace WinningGroup.Infrastructure
{
    public interface IProductsDBConnection
    {
        IMongoCollection<Product> GetProductsCollection();
    }

    public class ProductsDBConnection : IProductsDBConnection
    {
        private MongoClient _client;

        public ProductsDBConnection()
        {
            const string connectionUri = "mongodb+srv://declanholmes90:Je1lmgTXegjLh4XS@cluster0.njckr.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _client = new MongoClient(settings);
        }

        public IMongoCollection<Product> GetProductsCollection()
        {
            var collection = _client.GetDatabase("Winning")
               .GetCollection<Product>("Products");

            return collection;
        }
    }
}
