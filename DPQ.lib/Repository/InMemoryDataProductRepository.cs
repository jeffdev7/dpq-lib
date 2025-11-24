using DPQ.lib.Interface;

namespace DPQ.lib.Repository
{
    /// <summary>
    /// In memory repository Data Products
    /// </summary>
    public class InMemoryDataProductRepository : IDataProductRepository
    {
        private readonly Dictionary<string, IDataProduct> _products = new();

        public Task RegisterAsync(IDataProduct product)
        {
            var key = $"{product.Domain}:{product.Name}";
            _products[key] = product;
            return Task.CompletedTask;
        }

        public Task<IDataProduct> GetAsync(string domain, string name)
        {
            var key = $"{domain}:{name}";
            _products.TryGetValue(key, out var product);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<IDataProduct>> ListAsync()
        {
            return Task.FromResult<IEnumerable<IDataProduct>>(_products.Values);
        }
    }
}
