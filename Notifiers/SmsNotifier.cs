using System;
using System.Threading.Tasks;
using Nml.Refactor.Me.Dependencies;
using Nml.Refactor.Me.MessageBuilders;

namespace Nml.Refactor.Me.Notifiers
{
	public class SmsNotifier : Notifier
    {
        private readonly ILogger _logger = LogManager.For<SmsNotifier>();
        public SmsNotifier(IStringMessageBuilder messageBuilder, IOptions options):base(messageBuilder, options)
		{
		}
		
		public override async Task Notify(NotificationMessage message)
		{
            //Complete after refactoring inheritance. Use "SmsApiClient"

            var smsApi = new SmsApiClient(_options.Sms.ApiUri, _options.Sms.ApiKey);
            var mailMessage = _messageBuilder.CreateMessage(message);

            try
            {
                await smsApi.SendAsync(message.To, (string)mailMessage);

                _logger.LogTrace($"Message sent.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to send message. {e.Message}");
                throw;
            }
                        
        }
    }
}
