using Domains.MessageClasses;
using Domains.UserClasses;

namespace Domains.NotificationClasses
{
    public class NotificationReceivedMessageGroupConversation : Notification
    {
        private GroupConversation _groupConversation;
        private Message _receivedMessage;

        public NotificationReceivedMessageGroupConversation(User adressee, GroupConversation groupConversation, Message receivedMessage) : base(adressee)
        {
            _groupConversation = groupConversation;
            _receivedMessage = receivedMessage;
        }

        public NotificationReceivedMessageGroupConversation(Guid id, DateTime timestamp, User adressee, GroupConversation groupConversation, Message receivedMessage) : base(id, timestamp, adressee)
        {
            _addressee = adressee;
            _groupConversation = groupConversation;
            _receivedMessage = receivedMessage;
        }

        public override string ShowNotification()
        {
            if (_groupConversation.ConversationName is null)
            {
                return $"{_receivedMessage.Sender.GetFullName()} sent a message to your group conversation.";
            }
            else
            {
                return $"{_receivedMessage.Sender.GetFullName()} sent a message to {_groupConversation.ConversationName}.";
            }
        }
    }
}
