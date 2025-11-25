using DPQ.lib.Enums;
using DPQ.lib.Interface;
using DPQ.lib.Strategies;

namespace DPQ.lib.Services
{
    /// <summary>
    /// Service for masking data
    /// </summary>
    public class MaskingService
    {
        private readonly List<IMaskingStrategy> _strategies = new();

        public MaskingService()
        {
            RegisterDefaultStrategies();
        }

        private void RegisterDefaultStrategies()
        {
            _strategies.Add(new CPFMaskingStrategy());
            _strategies.Add(new EmailMaskingStrategy());
            _strategies.Add(new PhoneMaskingStrategy());
            _strategies.Add(new CreditCardMaskingStrategy());
        }

        public void RegisterStrategy(IMaskingStrategy strategy)
        {
            _strategies.Add(strategy);
        }
        /// <summary>
        /// Mask function
        /// 
        /// Strategies: CPF, CreditCard, Phone, Email
        /// 
        /// Example: Mask(yourField, "CPF", MaskingLevel.Full);
        /// 
        /// </summary>
        public string Mask(string value, string strategyName, MaskingLevel level)
        {
            var strategy = _strategies.FirstOrDefault(s => s.CanHandle(strategyName));
            return strategy?.Mask(value, level) ?? value;
        }
    }
}
