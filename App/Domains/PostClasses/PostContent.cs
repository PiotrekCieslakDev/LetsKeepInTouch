namespace Domains.PostClasses
{
    public class PostContent
    {
        private Guid _id;
        private string _contentText;
        private DateTime _creationTime;

        public PostContent(string contentText)
        {
            _id = Guid.NewGuid();
            _contentText = contentText;
            _creationTime = DateTime.Now;
        }

        public PostContent(Guid id, string contentText, DateTime creationTime)
        {
            _id = id;
            _contentText = contentText;
            _creationTime = creationTime;
        }

        public Guid Id { get => _id; }
        public string ContentText { get => _contentText; }
        public DateTime CreationTime { get => _creationTime; }
    }
}