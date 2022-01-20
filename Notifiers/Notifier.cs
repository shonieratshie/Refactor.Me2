using System;
using System.Threading.Tasks;
using Nml.Refactor.Me.Dependencies;
using Nml.Refactor.Me.MessageBuilders;

namespace Nml.Refactor.Me.Notifiers
{
    public abstract class Notifier: INotifier
    {
        protected readonly IMessageBuilder<object> _messageBuilder;
        protected readonly IOptions _options;
       
        public Notifier(IMessageBuilder<object> messageBuilder, IOptions options)
        {
            _messageBuilder = messageBuilder ?? throw new ArgumentNullException(nameof(messageBuilder));
            _options = options ?? throw new ArgumentNullException(nameof(options));
         
        }

        public abstract Task Notify(NotificationMessage message);

    }
}
