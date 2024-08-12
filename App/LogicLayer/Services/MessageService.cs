using DataAccessLayerInterfaces;
using Domains.MessageClasses;
using Domains.ResultClasses;

namespace LogicLayer.Services
{
    public class MessageService
    {
        private List<Conversation> _conversations = new List<Conversation>();
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public List<Conversation> GetAllConversations()
        {
            return _conversations;
        }
        public List<Conversation> GetAllUsersConversations(Guid userId)
        {
            return _conversations.FindAll(conversation => conversation.Users.Any(user => user.Id == userId));
        }
        public Conversation? GetConversationById(Guid conversationId)
        {
            return _conversations.Find(conversation => conversation.Id  == conversationId);
        }

        public Result CreateConversation(Conversation conversation)
        {
            _conversations.Add(conversation);
            return new Result(true, "Conversation created.");
        }

        public Result CreateMessage(Message message, Guid conversationId)
        {
            Conversation? conversation = _conversations.Find(conversation => conversation.Id == conversationId);
            if (conversation != null)
            {
                return conversation.AddMessage(message);
            }
            else
            {
                return new Result(true, "Conversation not found.");
            }
        }
    }
}
