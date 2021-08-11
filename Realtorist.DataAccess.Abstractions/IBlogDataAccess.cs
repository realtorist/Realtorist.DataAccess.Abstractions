using Realtorist.Models.Blog;
using Realtorist.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtorist.DataAccess.Abstractions
{
    /// <summary>
    /// Describes data access to blog posts
    /// </summary>
    public interface IBlogDataAccess
    {
        /// <summary>
        /// Adds new comment to the blog post
        /// </summary>
        /// <param name="postId">Id of the post to which add the comment</param>
        /// <param name="comment">Comment to add</param>
        /// <returns>Comment id</returns>
        Task<Guid> AddCommentAsync(Guid postId, Comment comment);

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>All blog posts</returns>
        Task<List<Post>> GetPostsAsync(bool includeNotPublished = false);

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <typeparam name="T">Projection type</typeparam>
        /// <returns>All blog posts</returns>
        Task<List<T>> GetPostsAsync<T>(bool includeNotPublished = false);

        /// <summary>
        /// Gets blog post by id
        /// </summary>
        /// <param name="postId">Id of the blog post</param>
        /// <returns>Blog post</returns>
        Task<Post> GetPostAsync(Guid postId);

        /// <summary>
        /// Gets blog post by it's link
        /// </summary>
        /// <param name="link">Link of the blog post</param>
        /// <returns>Blog post</returns>
        Task<Post> GetPostAsync(string link);

        /// <summary>
        /// Gets blog posts with pagination
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Pagination result</returns>
        Task<PaginationResult<Post>> GetPostsAsync(PaginationRequest request, bool includeNotPublished = false);

        /// <summary>
        /// Gets blog posts with pagination
        /// </summary>
        /// <typeparam name="T">Projection type</typeparam>
        /// <param name="request">Pagination request</param>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Pagination result</returns>
        Task<PaginationResult<T>> GetPostsAsync<T>(PaginationRequest request, bool includeNotPublished = false);

        /// <summary>
        /// Gets pagination result of posts from specific category
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="category">Category</param>
        /// <returns>Category posts</returns>
        Task<PaginationResult<Post>> GetCategoryPostsAsync(PaginationRequest request, string category, bool includeNotPublished = false);

        /// <summary>
        /// Gets pagination result of posts from specific category
        /// </summary>
        /// <typeparam name="T">Projection type</typeparam>
        /// <param name="request">Pagination request</param>
        /// <param name="category">Category</param>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Category posts</returns>
        Task<PaginationResult<T>> GetCategoryPostsAsync<T>(PaginationRequest request, string category, bool includeNotPublished = false);

        /// <summary>
        /// Gets pagination result of posts with specific tag
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="tag">Tag</param>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Posts with tag</returns>
        Task<PaginationResult<Post>> GetPostsByTagAsync(PaginationRequest request, string tag, bool includeNotPublished = false);

        /// <summary>
        /// Gets pagination result of posts with specific tag
        /// </summary>
        /// <typeparam name="T">Projection type</typeparam>
        /// <param name="request">Pagination request</param>
        /// <param name="tag">Tag</param>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Posts with tag</returns>
        Task<PaginationResult<T>> GetPostsByTagAsync<T>(PaginationRequest request, string tag, bool includeNotPublished = false);

        /// <summary>
        /// Gets pagination result of blog post search
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="query">Search query</param>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Blog posts search result</returns>
        Task<PaginationResult<Post>> SearchPostsAsync(PaginationRequest request, string query, bool includeNotPublished = false);

        /// <summary>
        /// Gets pagination result of blog post search
        /// </summary>
        /// <typeparam name="T">Projection type</typeparam>
        /// <param name="request">Pagination request</param>
        /// <param name="query">Search query</param>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Blog posts search result</returns>
        Task<PaginationResult<T>> SearchPostsAsync<T>(PaginationRequest request, string query, bool includeNotPublished = false);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Categories</returns>
        Task<Dictionary<string, int>> GetCategoriesAsync(bool includeNotPublished = false);

        /// <summary>
        /// Gets all tags
        /// </summary>
        /// <param name="includeNotPublished">Indicates whether to include posts with publish data after now</param>
        /// <returns>Tags</returns>
        Task<List<string>> GetTagsAsync(bool includeNotPublished = false);

        /// <summary>
        /// Adds new blog post
        /// </summary>
        /// <param name="blogPost">Post to add</param>
        /// <returns>Post id</returns>
        Task<Guid> AddPostAsync(PostUpdateModel blogPost);

        /// <summary>
        /// Updates the blog post
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <param name="post">New post information</param>
        Task UpdatePostAsync(Guid postId, PostUpdateModel post);

        /// <summary>
        /// Removes the blog post id
        /// </summary>
        /// <param name="postId">Id of the post</param>
        Task RemovePostAsync(Guid postId);

        /// <summary>
        /// Gets post's comments
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <param name="request">Pagination request</param>
        /// <returns>Blog post's comments</returns>
        Task<PaginationResult<CommentListModel>> GetPostCommentsAsync(Guid postId, PaginationRequest request);

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <returns>Blog comments</returns>
        Task<PaginationResult<CommentListModel>> GetCommentsAsync(PaginationRequest request);

        /// <summary>
        /// Removes the comment
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <param name="commentId">Id of the comment to review</param>
        Task RemoveCommentAsync(Guid postId, Guid commentId);

        /// <summary>
        /// Increments number of views for the post by 1
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <returns></returns>
        Task IncrementPostViews(Guid postId);

        /// <summary>
        /// Checks if link for the blog post is used
        /// </summary>
        /// <param name="link">Link to check</param>
        /// <param name="idsToExclude">List of ids to exclude in the check</param>
        /// <returns>Whether link is used</returns>
        Task<bool> IsLinkUsed(string link, IEnumerable<Guid> idsToExclude = null);
    }
}
