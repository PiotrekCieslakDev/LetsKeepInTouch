using Domains.PostClasses;

namespace LogicLayer.PostStrategies.PostsListSortingAndFiltering
{
    public class PostsFromTheNewsestToOldestSorting : ISortFilterPost
    {
        public List<Post> SortAndFilter(List<Post> givenPosts)
        {
            return givenPosts.OrderByDescending(post => post.GetFirstPostDate()).ToList();
        }
    }
}
