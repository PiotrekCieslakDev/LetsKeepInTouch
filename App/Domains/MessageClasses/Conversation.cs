using Domains.ResultClasses;
using Domains.UserClasses;
using System.ComponentModel;

namespace Domains.MessageClasses
{
    public class Conversation
    {
        private Guid _id;
        private List<User> _users;
        private List<Message> _messages;

        public Conversation(User firstUser, User secondUser)
        {
            _id = Guid.NewGuid();
            _users = new List<User>()
            {
                firstUser,
                secondUser
            };
            _messages = new List<Message>();
        }

        public Conversation(Guid id, User firstUser, User secondUser, List<Message> messages)
        {
            _id = id;
            _users = new List<User>()
            {
                firstUser,
                secondUser
            };
            _messages = messages;
        }

        public Guid Id { get => _id; }
        public List<User> Users { get => _users; }

        public Message? GetRecentMessageOfThisConversation()
        {
            return _messages.OrderByDescending(message => message.TimeStamp).FirstOrDefault();
        }

        public Result AddMessage(Message message)
        {
            if (message.Sender != null && _users.Any(user => user.Id == message.Sender.Id))
            {
                _messages.Add(message);
                return new Result(true, "Sent the message.");
            }
            else
            {
                return new Result(false, "You can't send message to that conversation. You are not a member.");
            }
        }

    }
}
