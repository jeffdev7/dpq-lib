namespace DPQ.lib.Interface
{
    /// <summary>
    /// Data Product Repository
    /// </summary>
    public interface IDataProductRepository
    {
        Task RegisterAsync(IDataProduct product);
        Task<IDataProduct> GetAsync(string domain, string name);
        Task<IEnumerable<IDataProduct>> ListAsync();
    }
}
