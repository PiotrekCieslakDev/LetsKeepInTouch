using Domains.PostClasses;
using Domains.ResultClasses;

namespace LogicLayer.UpdatingPost
{
    public interface IMakeAPostUpdate
    {
        public GetPostResult ProcessUpdate(Post postToBeUpdated);
    }
}
