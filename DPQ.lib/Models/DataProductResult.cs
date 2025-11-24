namespace DPQ.lib.Models
{
    public class DataProductResult
    {
        public bool Success { get; set; }
        public Dictionary<string, object> Data { get; set; } = new();
        public List<string> Errors { get; set; } = new();
        public DataProductMetadata Metadata { get; set; }
        public DateTime RetrievedAt { get; set; } = DateTime.UtcNow;
    }
}
