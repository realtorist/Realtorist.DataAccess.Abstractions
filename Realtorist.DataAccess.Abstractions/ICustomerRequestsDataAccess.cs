using Realtorist.Models.CustomerRequests;
using Realtorist.Models.Dto;
using Realtorist.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtorist.DataAccess.Abstractions
{
    /// <summary>
    /// Describes access to the customer requests
    /// </summary>
    public interface ICustomerRequestsDataAccess
    {
        /// <summary>
        /// Gets customer requests
        /// </summary>
        /// <param name="paginationRequest">Pagination request</param>
        /// <returns>Customer requests</returns>
        Task<PaginationResult<CustomerRequest>> GetCustomerRequestsAsync(PaginationRequest paginationRequest);

        /// <summary>
        /// Gets customer requests
        /// </summary>
        /// <param name="paginationRequest">Pagination request</param>
        /// <typeparam name="T">Projection type</typeparam>
        /// <returns>Customer requests</returns>
        Task<PaginationResult<T>> GetCustomerRequestsAsync<T>(PaginationRequest paginationRequest);

        /// <summary>
        /// Gets customer request
        /// </summary>
        /// <param name="id">Request id</param>
        /// <returns>Customer request</returns>
        Task<CustomerRequest> GetCustomerRequestAsync(Guid id);

        /// <summary>
        /// Adds reply to the request
        /// </summary>
        /// <param name="id">Request id</param>
        Task ReplyAsync(Guid id, CustomerRequestReply reply);

        /// <summary>
        /// Deletes customer request
        /// </summary>
        /// <param name="id">Request id</param>
        Task DeleteCustomerRequestAsync(Guid id);

        /// <summary>
        /// Gets count of unread customer requests
        /// </summary>
        /// <returns>Count of unread customer requests</returns>
        Task<int> GetUnreadCustomerRequestsCountAsync();

        /// <summary>
        /// Adds new customer request
        /// </summary>
        /// <param name="customerRequest">Customer request</param>
        Task AddCustomerRequestAsync(RequestInformationModel customerRequest);

        /// <summary>
        /// Marks customer request as read
        /// </summary>
        /// <param name="id">Id of the request</param>
        /// <param name="read">Is request read</param>
        Task MarkRequestAsReadAsync(Guid id, bool read = true);

        /// <summary>
        /// Marks customer requests as read
        /// </summary>
        /// <param name="ids">Ids of requests</param>
        /// <param name="read">Is request read</param>
        Task MarkRequestsAsReadAsync(IEnumerable<Guid> ids, bool read = true);

        /// <summary>
        /// Marks all customer requests as read
        /// </summary>
        /// <param name="read">Is request read</param>
        Task MarkAllRequestsAsReadAsync(bool read = true);
    }
}
