namespace LogicLayer.UpdatingPost.Parameters
{
    public class DeletePostAsUser : ParametersToChangePost
    {
        private readonly bool _delete;

        public DeletePostAsUser(bool delete)
        {
            _delete = delete;
        }
    }
}
