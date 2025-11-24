using DPQ.lib.Enums;
using DPQ.lib.Interface;
using DPQ.lib.Services;

namespace DPQ.lib.Strategies
{
    /// <summary>
    /// Email masking
    /// </summary>
    public class EmailMaskingStrategy : IMaskingStrategy
    {
        public bool CanHandle(string strategyName) => strategyName == "Email";

        public string Mask(string value, MaskingLevel level)
        {
            if (string.IsNullOrEmpty(value)) 
                return value;

            return level switch
            {
                MaskingLevel.None => value,
                MaskingLevel.Partial => MaskEmailPartial(value),
                MaskingLevel.Full => "***@***.***",
                MaskingLevel.Encrypted => EncryptionService.Encrypt(value),
                _ => value
            };
        }

        private string MaskEmailPartial(string email)
        {
            var parts = email.Split('@');
            if (parts.Length != 2) return email;

            var username = parts[0];
            if (username.Length <= 2) return $"***@{parts[1]}";

            return $"{username[0]}***{username[^1]}@{parts[1]}";
        }
    }
}
