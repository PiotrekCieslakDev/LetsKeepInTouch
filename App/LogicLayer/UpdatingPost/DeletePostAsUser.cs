using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;

namespace LogicLayer.UpdatingPost
{
    public class DeletePostAsUser : IMakeAPostUpdate
    {
        private readonly User _operatingUser;
        private readonly bool _delete;

        public DeletePostAsUser(User operatingUser, bool delete)
        {
            _operatingUser = operatingUser;
            _delete = delete;
        }

        public GetPostResult ProcessUpdate(Post postToBeUpdated)
        {
            Result result = postToBeUpdated.DeletePost(_operatingUser.Id);
            return new GetPostResult(result.IsSuccess, result.Message, postToBeUpdated);
        }
    }
}
