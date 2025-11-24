using DPQ.lib.Enums;

namespace DPQ.lib.Interface
{
    public interface IMaskingStrategy
    {
        string Mask(string value, MaskingLevel level);
        bool CanHandle(string strategyName);
    }
}
