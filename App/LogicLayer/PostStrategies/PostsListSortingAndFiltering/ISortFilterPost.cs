using Domains.PostClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.PostStrategies.PostsListSortingAndFiltering
{
    public interface ISortFilterPost
    {
        public List<Post> SortAndFilter(List<Post> givenPosts);
    }
}
