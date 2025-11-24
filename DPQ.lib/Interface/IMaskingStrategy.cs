using DPQ.lib.Enums;

namespace DPQ.lib.Interface
{
    /// <summary>
    /// MakingStrategy
    /// </summary>
    public interface IMaskingStrategy
    {
        string Mask(string value, MaskingLevel level);
        bool CanHandle(string strategyName);
    }
}
