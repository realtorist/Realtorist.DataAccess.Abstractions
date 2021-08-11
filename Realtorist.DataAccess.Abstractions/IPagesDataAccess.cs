using Realtorist.Models.Blog;
using Realtorist.Models.Page;
using Realtorist.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtorist.DataAccess.Abstractions
{
    /// <summary>
    /// Describes data access to pages
    /// </summary>
    public interface IPagesDataAccess
    {
        /// <summary>
        /// Gets page by id
        /// </summary>
        /// <param name="postId">Id of the page</param>
        /// <returns>Page</returns>
        Task<Page> GetPageAsync(Guid pageId);

        /// <summary>
        /// Gets page by it's link
        /// </summary>
        /// <param name="link">Link of the page</param>
        /// <returns>Page</returns>
        Task<Page> GetPageAsync(string link);

        /// <summary>
        /// Gets all pages
        /// </summary>
        /// <param name="includeNotPublished">Indicates whether to include unpublished pages</param>
        /// <returns>All pages</returns>
        Task<List<Page>> GetPagesAsync(bool includeNotPublished = false);

        /// <summary>
        /// Gets pages with pagination
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="includeNotPublished">Indicates whether to include unpublished pages</param>
        /// <returns>Pagination result</returns>
        Task<PaginationResult<Page>> GetPagesAsync(PaginationRequest request, bool includeNotPublished = false);

        /// <summary>
        /// Gets pages with pagination
        /// </summary>
        /// <typeparam name="T">Projection type</typeparam>
        /// <param name="request">Pagination request</param>
        /// <param name="includeNotPublished">Indicates whether to include unpublished pages</param>
        /// <returns>Pagination result</returns>
        Task<PaginationResult<T>> GetPagesAsync<T>(PaginationRequest request, bool includeNotPublished = false);

        /// <summary>
        /// Adds new page
        /// </summary>
        /// <param name="page">Page to add</param>
        /// <returns>Page id</returns>
        Task<Guid> AddPageAsync(PageUpdateModel page);

        /// <summary>
        /// Updates the page
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <param name="page">New page information</param>
        Task UpdatePageAsync(Guid pageId, PageUpdateModel page);

        /// <summary>
        /// Removes the page
        /// </summary>
        /// <param name="pageId">Id of the page</param>
        Task RemovePageAsync(Guid pageId);

        /// <summary>
        /// Increments number of views for the page by 1
        /// </summary>
        /// <param name="pageId">Id of the page</param>
        Task IncrementPagetViews(Guid pageId);

        /// <summary>
        /// Checks if link for the page is used
        /// </summary>
        /// <param name="link">Link to check</param>
        /// <param name="idsToExclude">List of ids to exclude in the check</param>
        /// <returns>Whether link is used</returns>
        Task<bool> IsLinkUsed(string link, IEnumerable<Guid> idsToExclude = null);
    }
}
