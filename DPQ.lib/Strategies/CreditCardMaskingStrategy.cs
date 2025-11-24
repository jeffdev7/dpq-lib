using DPQ.lib.Enums;
using DPQ.lib.Interface;
using DPQ.lib.Services;
using System.Text.RegularExpressions;

namespace DPQ.lib.Strategies
{
    /// <summary>
    /// Credit card masking
    /// </summary>
    public class CreditCardMaskingStrategy : IMaskingStrategy
    {
        public bool CanHandle(string strategyName) => strategyName == "CreditCard";

        public string Mask(string value, MaskingLevel level)
        {
            if (string.IsNullOrEmpty(value)) 
                return value;

            return level switch
            {
                MaskingLevel.None => value,
                MaskingLevel.Partial => Regex.Replace(value, @"(\d{4})\s?(\d{4})\s?(\d{4})\s?(\d{4})", "**** **** **** $4"),
                MaskingLevel.Full => "**** **** **** ****",
                MaskingLevel.Encrypted => EncryptionService.Encrypt(value),
                _ => value
            };
        }
    }
}
