using DPQ.lib.Enums;
using DPQ.lib.Interface;
using DPQ.lib.Services;
using System.Text.RegularExpressions;

namespace DPQ.lib.Strategies
{

    public class CPFMaskingStrategy : IMaskingStrategy
    {
        public bool CanHandle(string strategyName) => strategyName == "CPF";

        public string Mask(string value, MaskingLevel level)
        {
            if (string.IsNullOrEmpty(value)) 
                return value;

            return level switch
            {
                MaskingLevel.None => value,
                MaskingLevel.Partial => Regex.Replace(value, @"(\d{3})\.?(\d{3})\.?(\d{3})-?(\d{2})", "***.***.***-$4"),
                MaskingLevel.Full => "***.***.***-**",
                MaskingLevel.Encrypted => EncryptionService.Encrypt(value),
                _ => value
            };
        }
    }
}
