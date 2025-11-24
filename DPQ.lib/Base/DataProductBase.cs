using DPQ.lib.Enums;
using DPQ.lib.Interface;
using DPQ.lib.Models;
using DPQ.lib.Services;

namespace DPQ.lib.Base
{
    /// <summary>
    /// Base class for implementation of Data Products
    /// </summary>
    public abstract class DataProductBase : IDataProduct
    {
        protected readonly MaskingService _maskingService;

        public abstract string Domain { get; }
        public abstract string Name { get; }
        public virtual string Version => "1.0.0";
        public DataProductMetadata Metadata { get; protected set; }

        protected DataProductBase()
        {
            _maskingService = new MaskingService();
            Metadata = new DataProductMetadata
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public abstract Task<DataProductResult> GetDataAsync(DataProductQuery query);

        protected Dictionary<string, object> ApplyMasking(
            Dictionary<string, object> data,
            Dictionary<string, string> maskingRules,
            MaskingLevel level)
        {
            if (level == MaskingLevel.None) 
                return data;

            var masked = new Dictionary<string, object>(data);

            foreach (var (field, strategy) in maskingRules)
            {
                if (data.ContainsKey(field) && data[field] is string value)
                {
                    masked[field] = _maskingService.Mask(value, strategy, level);
                }
            }

            return masked;
        }
    }
}
