using Domains.PostClasses;

namespace LogicLayer.PostStrategies.PostsListSortingAndFiltering
{
    public class AllPostsBySpecificUser : ISortFilterPost
    {
        private Guid _userId;

        public AllPostsBySpecificUser(Guid userId)
        {
            _userId = userId;
        }

        public List<Post> SortAndFilter(List<Post> givenPosts)
        {
            return givenPosts.FindAll(post => post.Author.Id == _userId);
        }
    }
}
