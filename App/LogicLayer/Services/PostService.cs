using DataAccessLayerInterfaces;
using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.PostStrategies.PostsListSortingAndFiltering;
using LogicLayer.UpdatingPost;
using LogicLayer.UpdatingPost.Parameters;
using LogicLayerInterfaces;

namespace LogicLayer.Services
{
    public class PostService : IPostService
    {
        private List<MainPost> _mainPosts;
        private readonly UserService _userService;
        private readonly NotificationService _notificationService;
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            _postRepository = postRepository;
            _userService = new UserService(userRepository);
            _notificationService = new NotificationService(notificationRepository);
        }

        public List<Post> GetAllPostsFromRepository(ISortFilterPost[]? sortFilterParameters)
        {
            List<Post>? retrivedPosts = _postRepository.GetAllPosts();
            if(retrivedPosts == null)
            {
                return new List<Post>();
            }
            if(sortFilterParameters != null && sortFilterParameters.Any() )
            {
                foreach (ISortFilterPost sortingFilteringProcess in sortFilterParameters)
                {
                    retrivedPosts = sortingFilteringProcess.SortAndFilter(retrivedPosts);
                }
            }
            return retrivedPosts;
        }
        public Post? GetPostById(Guid postId)
        {
            try
            {
                if (postId == Guid.Empty)
                {
                    throw new ArgumentException("PostId cannot be empty.", nameof(postId));
                }

                return _postRepository.GetPostById(postId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting the post by ID: {ex.Message}");
                return null;
            }
        }
        public MainPost? GetPostWithComments(Guid mainPostId, bool restricted, bool deleted)
        {
            MainPost? postToGet = (MainPost)_postRepository.GetPostById(mainPostId);
            if (postToGet == null)
            {
                return null;
            }

            List<Comment>? comments = _postRepository.GetAllCommentsOnPostByPostId(mainPostId);
            if (comments != null && comments.Count > 0)
            {
                List<Comment> filteredComments = new List<Comment>();
                foreach (Comment comment in comments)
                {
                    if (comment.Restricted == restricted && comment.Deleted == deleted)
                    {
                        filteredComments.Add(comment);
                    }
                }
                postToGet.Comments = filteredComments;
            }
            return postToGet;
        }
        public MainPost? GetMainPostByItsComment(Guid commentId)
        {
            return _postRepository.GetMainPostByItsComment(commentId);
        }

        public Result CreatePost(Post post)
        {
            try
            {
                if (post == null)
                {
                    throw new ArgumentNullException(nameof(post), "Post cannot be null.");
                }

                return _postRepository.CreatePost(post);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the post: {ex.Message}");
                return new Result(false, "An error occurred while creating the post.");
            }
        }
        public Result UpdatePost(Guid postToBeUpdatedId, IMakeAPostUpdate[] makeAPostUpdates)
        {
            Post? postToBeUpdate = _postRepository.GetPostById(postToBeUpdatedId);

            if (postToBeUpdate == null)
            {
                Console.WriteLine("Could not find a post to update");
                return new Result(false, "Could not find a post to update");
            }

            int expectedSuccesses = makeAPostUpdates.Count();
            int actualSuccesses = 0;
            foreach (var makeAPostUpdate in makeAPostUpdates)
            {
                GetPostResult resultOfUpdate = makeAPostUpdate.ProcessUpdate(postToBeUpdate);
                postToBeUpdate = resultOfUpdate.Post;
                if (resultOfUpdate.IsSuccess)
                {
                    actualSuccesses++;
                }
                else
                {
                    return resultOfUpdate;
                }
            }
            if (expectedSuccesses == actualSuccesses)
            {
                return _postRepository.UpdatePost(postToBeUpdate);
            }
            else
            {
                return new Result(false, "Something went wrong. Try again.");
            }
        }
        public Result MakePostEdit(User author, Guid postId, string content)
        {
            try
            {
                if (author == null)
                {
                    throw new ArgumentNullException(nameof(author), "Author cannot be null.");
                }

                Post? existingPost = _postRepository.GetPostById(postId);
                if (existingPost == null)
                {
                    return new Result(false, "Failed to find the post for editing.");
                }

                Result result = existingPost.EditPost(author, content);

                if (result.IsSuccess)
                {
                    return _postRepository.EditPost(postId, existingPost.GetLatestPostContent());
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while making post edit: {ex.Message}");
                return new Result(false, "An error occurred while making post edit.");
            }
        }
        public Result CreatingCommentOnAPost(Comment newComment, Guid commentedPostId)
        {
            try
            {
                if (newComment == null)
                {
                    return new Result(false, "New comment cannot be null.");
                }

                Post? commentedPost = _postRepository.GetPostById(commentedPostId);

                if (commentedPost != null)
                {
                    MainPost commentedMainPost = commentedPost as MainPost;

                    Result result = commentedMainPost.AddComment(newComment);
                    return _postRepository.CreateComment(newComment, commentedPostId);
                }

                return new Result(false, "Failed to find the post for commenting.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating a comment on a post: {ex.Message}");
                return new Result(false, "An error occurred while creating a comment on a post.");
            }
        }

        public List<MainPost> TransformPostsToMainPost(List<Post> givenPosts)
        {
            List<MainPost> transformedPosts = new List<MainPost>();
            foreach (Post post in givenPosts)
            {
                if (post is MainPost mainPost)
                {
                    transformedPosts.Add(mainPost);
                }
            }
            return transformedPosts;
        }

        //public Result TogglePostLike(Guid authorId, Guid postId)
        //{
        //    Post? post = _postRepository.GetPostById(postId);
        //    if (post != null)
        //    {
        //        User? likingUser = _userService.GetUserById(authorId);
        //        if (likingUser != null)
        //        {
        //            if (post.IsLikedByUser(likingUser))
        //            {
        //                return post.UnLike(likingUser);
        //            }
        //            else
        //            {
        //                Result result = post.Like(likingUser);
        //                //if (result.IsSuccess)
        //                //{
        //                //    _notificationService.CreateNotification(new NotificationPostLiked(post.Author, likingUser, post));
        //                //}
        //                return result;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return new Result(false, "We could not find this post.");
        //    }
        //    return new Result(false, "Something went wrong while adding the post edit.");
        //}
        //public Result TogglePostRestriction(Guid postId, bool restriction)
        //{
        //    try
        //    {
        //        if (postId == Guid.Empty)
        //        {
        //            return new Result(false, "PostId cannot be empty.");
        //        }

        //        return _postRepository.TogglePostRestriction(postId, restriction);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred while toggling post restriction: {ex.Message}");
        //        return new Result(false, "An error occurred while toggling post restriction.");
        //    }
        //}
        //public Result RestrictAllPostsMadeByUserByTheirId(Guid userId)
        //{
        //    try
        //    {
        //        if (userId == Guid.Empty)
        //        {
        //            return new Result(false, "UserId cannot be empty.");
        //        }

        //        return _postRepository.RestrictAllPostsMadeByUserByTheirId(userId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred while restricting all posts made by the user: {ex.Message}");
        //        return new Result(false, "An error occurred while restricting all posts made by the user.");
        //    }
        //}
    }
}