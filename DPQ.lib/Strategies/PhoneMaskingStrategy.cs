using DPQ.lib.Enums;
using DPQ.lib.Interface;
using DPQ.lib.Services;
using System.Text.RegularExpressions;

namespace DPQ.lib.Strategies
{
    /// <summary>
    /// Phone masking
    /// </summary>
    public class PhoneMaskingStrategy : IMaskingStrategy
    {
        public bool CanHandle(string strategyName) => strategyName == "Phone";

        public string Mask(string value, MaskingLevel level)
        {
            if (string.IsNullOrEmpty(value)) 
                return value;

            return level switch
            {
                MaskingLevel.None => value,
                MaskingLevel.Partial => Regex.Replace(value, @"(\d{4})-?(\d{4})", "****-$2"),
                MaskingLevel.Full => "(***) ****-****",
                MaskingLevel.Encrypted => EncryptionService.Encrypt(value),
                _ => value
            };
        }
    }
}
