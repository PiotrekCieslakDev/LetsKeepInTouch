using Domains.ResultClasses;
using Domains.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.ReportClasses
{
    public abstract class Report
    {
        private Guid _id;
        protected User _reporter;
        private string _reportComment;
        protected DateTime _timeStamp;
        protected bool _reviewed;

        public Guid Id { get => _id; }
        public User Reporter { get => _reporter;  }
        public string ReportComment { get => _reportComment; }
        public DateTime TimeStamp { get => _timeStamp; }
        public bool Reviewed { get => _reviewed; }

        protected Report(User reporter, string reportComment)
        {
            _id = Guid.NewGuid();
            _reporter = reporter;
            _reportComment = reportComment;
            _timeStamp = DateTime.Now;
            _reviewed = false;
        }

        protected Report(Guid id, User reporter, DateTime timeStamp, bool reviewed, string reportComment)
        {
            _id = id;
            _reporter = reporter;
            _reportComment = reportComment;
            _timeStamp = timeStamp;
            _reviewed = reviewed;
        }

        public Result Review()
        {
            _reviewed = true;
            return new Result(true, "Ticked as reviwed");
        }

        public abstract string GetInfoAboutReport();

        public override string ToString()
        {
            return $"Report filed by {_reporter.GetFullNameWithUserNameAndEmail}";
        }
    }
}
