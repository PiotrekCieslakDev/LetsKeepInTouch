using Domains.PostClasses;

namespace LogicLayer.PostStrategies.PostsListSortingAndFiltering
{
    public class GetNotRestrictedNotDeletedPosts : ISortFilterPost
    {
        public List<Post> SortAndFilter(List<Post> givenPosts)
        {
            return givenPosts.FindAll(post => post.Restricted == false && post.Deleted == false);
        }
    }
}
