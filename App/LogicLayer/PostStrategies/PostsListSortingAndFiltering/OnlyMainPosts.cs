using Domains.PostClasses;

namespace LogicLayer.PostStrategies.PostsListSortingAndFiltering
{
    public class OnlyMainPosts : ISortFilterPost
    {
        public List<Post> SortAndFilter(List<Post> givenPosts)
        {
            return givenPosts.FindAll(post => post is MainPost);
        }
    }
}
