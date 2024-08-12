using Domains.UserClasses;

namespace Domains.MessageClasses
{
    public class GroupConversation : Conversation
    {
        private string? _conversationName;

        public GroupConversation(User firstUser, User secondUser) : base(firstUser, secondUser)
        {

        }

        public GroupConversation(Guid id, User firstUser, User secondUser, List<Message> messages, string conversationName) : base(id, firstUser, secondUser, messages)
        {
            _conversationName = conversationName;
        }

        public string? ConversationName { get => _conversationName; set => _conversationName = value; }
    }
}
