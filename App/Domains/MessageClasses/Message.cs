using Domains.UserClasses;

namespace Domains.MessageClasses
{
    public class Message
    {
        private Guid _id;
        private User _sender;
        private string _content;
        private DateTime _timeStamp;

        public Message(User sender, string content)
        {
            _id = Guid.NewGuid();
            _sender = sender;
            _content = content;
            _timeStamp = DateTime.Now;
        }

        public Message(Guid id, User sender, string content, DateTime timeStamp)
        {
            _id = id;
            _sender = sender;
            _content = content;
            _timeStamp = timeStamp;
        }

        public User Sender { get => _sender; }
        public DateTime TimeStamp { get => _timeStamp; }
    }
}
