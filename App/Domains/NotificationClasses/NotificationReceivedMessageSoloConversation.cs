using Domains.MessageClasses;
using Domains.UserClasses;
using Microsoft.VisualBasic;

namespace Domains.NotificationClasses
{
    public class NotificationReceivedMessageSoloConversation : Notification
    {
        Conversation _conversation;
        Message _receviedMessage;

        public NotificationReceivedMessageSoloConversation(User adressee, Conversation conversation, Message receviedMessage) : base(adressee)
        {
            _conversation = conversation;
            _receviedMessage = receviedMessage;
        }

        public NotificationReceivedMessageSoloConversation(Guid id, DateTime timestamp, User adressee, Conversation conversation, Message receviedMessage) : base(id, timestamp, adressee)
        {
            _conversation = conversation;
            _receviedMessage = receviedMessage;
        }

        public override string ShowNotification()
        {
            return $"{_receviedMessage.Sender.GetFullName()} sent you a message.";
        }
    }
}
