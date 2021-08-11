using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Realtorist.Models.Events;
using Realtorist.Models.Pagination;

namespace Realtorist.DataAccess.Abstractions
{
    /// <summary>
    /// Describes access to the events
    /// </summary>
    public interface IEventsDataAccess
    {
        /// <summary>
        /// Gets events
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="filter">Filter</param>
        /// <returns>Events</returns>
        Task<PaginationResult<Event>> GetEventsAsync(PaginationRequest request, IDictionary<string, string> filter);

        /// <summary>
        /// Gets events starting from UTC date
        /// </summary>
        /// <param name="startTimeUtc">Start time in UTC</param>
        /// <returns>Events</returns>
        Task<List<Event>> GetEventsAsync(DateTime startTimeUtc);

        /// <summary>
        /// Deletes all events
        /// </summary>
        /// <returns>Number of deleted events</returns>
        Task<long> DeleteAllEventsAsync();

        /// <summary>
        /// Deletes all events older than <paramref name="maxDate"/>
        /// </summary>
        /// <param name="maxDate">Max date of the events to keep</param>
        /// <returns>Number of deleted events</returns>
        Task<long> DeleteOldEventsAsync(DateTime maxDate);

        /// <summary>
        /// Creates new event
        /// </summary>
        /// <param name="eventToAdd">Event to add</param>
        /// <returns>Id of the event</returns>
        Task<Guid> CreateEventAsync(Event eventToAdd);
    }
}
