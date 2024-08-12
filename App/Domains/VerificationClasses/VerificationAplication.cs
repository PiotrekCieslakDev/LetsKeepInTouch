using Domains.UserClasses;

namespace Domains.VerificationClasses
{
    public class VerificationAplication
    {
        private Guid _id;
        private User _userToBeVerified;
        private string _verificationJustification;
        private DateTime _timeStamp;
        private bool _reviewed;

        public VerificationAplication(User userToBeVerified, string verificationJustification)
        {
            _id = Guid.NewGuid();
            _userToBeVerified = userToBeVerified;
            _verificationJustification = verificationJustification;
            _timeStamp = DateTime.Now;
            _reviewed = false;
        }

        public Guid Id { get => _id; }
        public User UserToBeVerified { get => _userToBeVerified; }
        public string VerificationJustification { get => _verificationJustification; }
        public DateTime TimeStamp { get => _timeStamp; }
        public bool Reviewed { get => _reviewed; }
    }
}
