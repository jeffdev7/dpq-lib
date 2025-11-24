using DPQ.lib.Enums;

namespace DPQ.lib.Models
{
    public class DataProductQuery
    {
        public MaskingLevel MaskingLevel { get; set; } = MaskingLevel.None;
        public AccessLevel RequiredAccessLevel { get; set; } = AccessLevel.Public;
        public Dictionary<string, object> Filters { get; set; } = new();
        public List<string> SelectFields { get; set; } = new();
        public string RequesterId { get; set; }
    }
}
