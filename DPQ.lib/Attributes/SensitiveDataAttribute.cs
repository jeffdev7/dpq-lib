using DPQ.lib.Enums;

namespace DPQ.lib.Attributes
{
    /// <summary>
    /// Label sensible properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SensitiveDataAttribute : Attribute
    {
        public DataClassification Classification { get; set; }
        public string MaskingStrategy { get; set; }

        public SensitiveDataAttribute(DataClassification classification, string maskingStrategy = "Default")
        {
            Classification = classification;
            MaskingStrategy = maskingStrategy;
        }
    }
}
