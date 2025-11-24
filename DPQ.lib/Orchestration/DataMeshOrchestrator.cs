using DPQ.lib.Interface;
using DPQ.lib.Models;
using DPQ.lib.Repository;

namespace DPQ.lib.Orchestration
{
    public class DataMeshOrchestrator
    {
        private readonly IDataProductRepository _repository;

        public DataMeshOrchestrator(IDataProductRepository repository = null)
        {
            _repository = repository ?? new InMemoryDataProductRepository();
        }

        public async Task RegisterDataProductAsync(IDataProduct product)
        {
            await _repository.RegisterAsync(product);
        }

        public async Task<DataProductResult> QueryAsync(string domain, string name, DataProductQuery query)
        {
            var product = await _repository.GetAsync(domain, name);

            if (product == null)
            {
                return new DataProductResult
                {
                    Success = false,
                    Errors = new List<string> { $"Data Product '{domain}:{name}' not found" }
                };
            }

            return await product.GetDataAsync(query);
        }

        public async Task<Dictionary<string, DataProductResult>> FederatedQueryAsync(
            List<(string domain, string name)> products,
            DataProductQuery query)
        {
            var results = new Dictionary<string, DataProductResult>();

            foreach (var (domain, name) in products)
            {
                var result = await QueryAsync(domain, name, query);
                results[$"{domain}:{name}"] = result;
            }

            return results;
        }

        public async Task<List<DataProductMetadata>> ListAvailableProductsAsync()
        {
            var products = await _repository.ListAsync();
            return products.Select(p => p.Metadata).ToList();
        }
    }
}
