namespace DPQ.lib.Models
{
    public class DataProductMetadata
    {
        public string Owner { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Dictionary<string, string> CustomProperties { get; set; } = new();
    }
}
