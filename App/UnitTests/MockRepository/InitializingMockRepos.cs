using Domains.PostClasses;
using Domains.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockRepository
{
    internal class InitializingMockRepos
    {
        private IEnumerable<User> allUsers;
        private IEnumerable<Post> allPosts;

        public IEnumerable<User> AllUsers { get => allUsers; }
        public IEnumerable<Post> AllPosts { get => allPosts; }

        internal InitializingMockRepos()
        {
            InitializeUsers();
            InitializePosts();
        }

        private void InitializeUsers()
        {
            allUsers = new List<User>()
            {
                new User("Julio", "Martinez", "JMartinez", "jmar@mail.com", "password", Enums.UserRole.Regular),
                new User("Roger", "Wilkers", "RogW", "rwilkers@adminkeepintouch", "password", Enums.UserRole.Admin)
            };
        }

        private void InitializePosts()
        {
            User author = allUsers.FirstOrDefault(user => user.FirstName == "Julio");
            allPosts = new List<Post>()
            {
                new Post(author, "Test post by Julio Martinez"),
                new Post(Guid.Parse("8e86dc87-d6e2-451e-82da-e9dca24595a7"), author, new List<PostContent>()
                {
                    new PostContent("Julio deleted post")
                }, false, true)
            };
        }
    }
}
