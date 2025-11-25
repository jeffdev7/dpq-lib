using DPQ.lib.Enums;

namespace DPQ.lib.Interface
{
    /// <summary>
    /// MaskingStrategy
    /// </summary>
    public interface IMaskingStrategy
    {
        string Mask(string value, MaskingLevel level);
        bool CanHandle(string strategyName);
    }
}
