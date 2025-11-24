namespace DPQ.lib.Interface
{
    public interface IDataProductRepository
    {
        Task RegisterAsync(IDataProduct product);
        Task<IDataProduct> GetAsync(string domain, string name);
        Task<IEnumerable<IDataProduct>> ListAsync();
    }
}
