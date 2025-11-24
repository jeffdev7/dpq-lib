using DPQ.lib.Models;

namespace DPQ.lib.Interface
{
    public interface IDataProduct
    {
        string Domain { get; }
        string Name { get; }
        string Version { get; }
        DataProductMetadata Metadata { get; }

        Task<DataProductResult> GetDataAsync(DataProductQuery query);
    }
}
