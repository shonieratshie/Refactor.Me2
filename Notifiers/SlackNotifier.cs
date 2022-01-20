using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nml.Refactor.Me.Dependencies;
using Nml.Refactor.Me.MessageBuilders;

namespace Nml.Refactor.Me.Notifiers
{
	public class SlackNotifier : Notifier
	{
        private readonly ILogger _logger = LogManager.For<SlackNotifier>();
        public SlackNotifier(IWebhookMessageBuilder messageBuilder, IOptions options):base(messageBuilder, options)
		{
		}

        public override async Task Notify(NotificationMessage message)
		{
			var serviceEndPoint = new Uri(_options.Slack.WebhookUri);
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Post, serviceEndPoint);
			request.Content = new StringContent(
				_messageBuilder.CreateMessage(message).ToString(),
				Encoding.UTF8,
				"application/json");
			
				var response = await client.SendAsync(request);
				_logger.LogTrace($"Message sent. {response.StatusCode} -> {response.Content}");
		}
	}
}
