using Domains.ResultClasses;
using Domains.UserClasses;

namespace Domains.PostClasses
{
    public class Post
    {
        private Guid _id;
        private User _author;
        private List<PostContent> _postContents;
        private bool _restricted;
        private bool _deleted;
        private List<Like> _likes;

        public Post(User author, string content)
        {
            _id = Guid.NewGuid();
            _author = author;
            _postContents = new List<PostContent>
            {
                new PostContent(content)
            };
            _restricted = false;
            _deleted = false;
            _likes = new List<Like>();
        }

        public Post(Guid id, User author, List<PostContent> postContents, bool restricted, bool deleted)
        {
            _id = id;
            _author = author;
            _postContents = postContents;
            _restricted = restricted;
            _deleted = deleted;
            _likes = new List<Like>();
        }

        public Post(Guid id, User author, List<PostContent> postContents, bool restricted, bool deleted, List<Like> likes)
        {
            _id = id;
            _author = author;
            _postContents = postContents;
            _restricted = restricted;
            _deleted = deleted;
            _likes = likes;
        }

        public Guid Id { get => _id; }
        public List<PostContent> PostContents
        {
            get
            {
                return _postContents;
            }
            set
            {
                _postContents = value.OrderByDescending(post => post.CreationTime).ToList();
            }
        }
        public User Author { get => _author; }
        public bool Deleted { get => _deleted; }
        public bool Restricted { get => _restricted; }

        public DateTime GetLatestPostsDate()
        {
            var latestPost = _postContents.OrderByDescending(post => post.CreationTime).FirstOrDefault();
            return latestPost.CreationTime;
        }

        public DateTime GetFirstPostDate()
        {
            var firstPost = _postContents.OrderByDescending(post => post.CreationTime).LastOrDefault();
            return firstPost.CreationTime;
        }

        public int GetNumberOfEdits()
        {
            return CountAllPostsContents() - 1;
        }

        public int CountAllPostsContents()
        {
            return _postContents.Count;
        }

        public PostContent GetLatestPostContent()
        {
            if (_postContents.Count() > 0)
            {
                return _postContents.OrderByDescending(post => post.CreationTime).FirstOrDefault();
            }
            else
            {
                return new PostContent("!THERE ARE NO POST CONTENTS!");
            }
        }

        public Result TogglePostRestriction(bool restriction)
        {
            if (_restricted && restriction)
            {
                return new Result(true, $"This post was already restricted.");
            }
            else if (_restricted && !restriction)
            {
                _restricted = restriction;
                return new Result(true, $"This post was restricted.");
            }
            else if (!_restricted && !restriction)
            {
                return new Result(true, $"This post was not restricted.");
            }
            else if (!_restricted && restriction)
            {
                _restricted = restriction;
                return new Result(true, $"This post was unrestricted.");
            }
            return new Result(false, $"Something went wrong.");
        }

        public Result EditPost(User editor, string content)
        {
            try
            {
                if (editor.Id == _author.Id)
                {
                    if (content.Length > 0)
                    {
                        _postContents.Add(new PostContent(content));
                        return new Result(true, "Post edit added");
                    }
                    return new Result(false, "Your post was to short. It has to have at least one character.");
                }
            }
            catch
            {
                throw new Exception("You are not the author of this post. You can't edit it.");
            }
            return new Result(false, "You are not the author of this post. You can't edit it.");
        }

        public Result DeletePost(Guid authorId)
        {
            if (_author.Id == authorId)
            {
                _deleted = true;
                return new Result(true, "Post deleted.");
            }
            else
            {
                return new Result(false, "You are not the author of this post. You can't delete it.");
            }
        }

        public bool IsLikedByUser(User user)
        {
            Like? like = _likes.Find(like => like.LikingUser.Id == user.Id);
            if (like != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Result Like(User likingUser)
        {
            Like? like = _likes.Find(like => like.LikingUser.Id == likingUser.Id);
            if (like == null)
            {
                if (Author.Id != likingUser.Id)
                {
                    _likes.Add(new Like(likingUser));
                    return new Result(true, $"{likingUser.GetFullNameWithUserName()} like this post.");
                }
                return new Result(true, $"You can't like your own post");
            }
            else
            {
                return new Result(false, $"{like.LikingUser.GetFullNameWithUserName()} already liked this post");
            }
        }
        public Result UnLike(User likingUser)
        {
            Like? like = _likes.Find(like => like.LikingUser.Id == likingUser.Id);
            if (like != null)
            {
                _likes.Remove(like);
                return new Result(true, "Unliked the post");
            }
            else
            {
                return new Result(false, "Could not find like made by this user");
            }
        }

        public Result ToggleLike(User likingUser)
        {
            Like? like = _likes.Find(like => like.LikingUser.Id == likingUser.Id);
            if (like is not null)
            {
                Like(likingUser);
                return new Result(true, "Post liked");
            }
            else
            {
                UnLike(likingUser);
                return new Result(true, "Post unliked");
            }
        }

        public Result RestrictPost(bool restrict)
        {
            if (!restrict && _restricted)
            {
                return new Result(true, "Note! This post was already restricted. If you really want to unrestrict it. Do it manually.");
            }
            _restricted = true;
            return new Result(true, "This post has been restricted.");
        }
    }
}
