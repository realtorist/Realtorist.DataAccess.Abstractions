using Realtorist.Models.Listings;
using Realtorist.Models.Listings.Enums;
using Realtorist.Models.Geo;
using Realtorist.Models.Pagination;
using Realtorist.Models.Search;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtorist.DataAccess.Abstractions
{
    /// <summary>
    /// Describes data access to the listings
    /// </summary>
    public interface IListingsDataAccess
    {
        /// <summary>
        /// Gets External IDs of all listings in the system
        /// </summary>
        /// <param name="source">Listing source</param>
        /// <returns>IDs of all listings in the system</returns>
        Task<List<string>> GetIdsAsync(ListingSource source);

        /// <summary>
        /// Gets all listings
        /// </summary>
        /// <returns>All listings</returns>
        Task<List<Listing>> GetAllListingsAsync();

        /// <summary>
        /// Gets all listings
        /// </summary>
        /// <typeparam name="T">Projection type</typeparam>
        /// <returns>All listings</returns>
        Task<List<T>> GetAllListingsAsync<T>();

        /// <summary>
        /// Gets all listings
        /// </summary>
        /// <returns>All listings</returns>
        Task<List<Listing>> GetListingsWithEmptyCoordinatesAsync();

        /// <summary>
        /// Gets listings
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="filter">Filter</param>
        /// <returns>Listings</returns>
        Task<PaginationResult<Listing>> GetListingsAsync(PaginationRequest request, IDictionary<string, string> filter);

        /// <summary>
        /// Gets listings
        /// </summary>
        /// <param name="request">Pagination request</param>
        /// <param name="filter">Filter</param>
        /// <returns>Listings</returns>
        Task<PaginationResult<T>> GetListingsAsync<T>(PaginationRequest request, IDictionary<string, string> filter);

        /// <summary>
        /// Gets listing by ID
        /// </summary>
        /// <param name="id">ID of the listing</param>
        /// <returns></returns>
        Task<Listing> GetListingAsync(Guid id);

        /// <summary>
        /// Removes listings by their IDs
        /// </summary>
        /// <param name="ids">IDs of the listings to remove</param>
        Task RemoveListingsAsync(IEnumerable<Guid> ids);

        /// <summary>
        /// Removes listings by their external IDs
        /// </summary>
        /// <param name="source">Listing source</param>
        /// <param name="externalIds">External IDs of the listings to remove</param>
        Task RemoveListingsAsync(ListingSource source, IEnumerable<string> externalIds);

        /// <summary>
        /// Removes listings by their IDs
        /// </summary>
        /// <param name="ids">IDs of the listings to remove</param>
        Task RemoveListingsAsync(params Guid[] ids);

        /// <summary>
        /// Gets the most recent date and time of the latest listings update
        /// </summary>
        /// <param name="source">Listing source</param>
        /// <returns>The most recent listing update time. Null - if no listing available</returns>
        Task<DateTime?> GetLatestUpdateDateTimeAsync(ListingSource source);

        // /// <summary>
        // /// Updates details of the listing
        // /// </summary>
        // /// <param name="id">ID of the listing</param>
        // /// <param name="details">New listing details</param>
        // Task UpdateListingDetailsAsync(Guid id, PropertyDetails details);

        /// <summary>
        /// Adds new listing
        /// </summary>
        /// <param name="listing">Listing</param>
        /// <returns>Listing id</returns>
        Task<Guid> AddNewListingAsync(Listing listing);

        /// <summary>
        /// Adds new listings
        /// </summary>
        /// <param name="details">Listings</param>
        Task AddNewListingsAsync(IEnumerable<Listing> listings);

        /// <summary>
        /// Updates details of the listing or adds new listing if doesn't exist
        /// </summary>
        /// <param name="id">ID of the listing</param>
        /// <param name="listing">New listing details</param>
        /// <returns>True if listing was updated and not added</returns>
        Task<bool> UpdateOrAddListingAsync(Guid id, Listing listing);

        /// <summary>
        /// Updates details of the listing or adds new listing if doesn't exist
        /// </summary>
        /// <param name="externalId">ID of the listing from MLS</param>
        /// <param name="source">Listing source</param>
        /// <param name="listing">New listing details</param>
        /// <param name="saveCoordinates">Indicates wheter to save coordinates</param>
        /// <param name="saveDisabledAndFeatured">Indicates whether to save disabled and featured fields</param>
        /// <returns>True if listing was updated and not added</returns>
        Task<bool> UpdateOrAddListingAsync(string externalId, ListingSource source, Listing listing, bool saveCoordinates = false, bool saveDisabledAndFeatured = false);

        /// <summary>
        /// Updates listing coordinates
        /// </summary>
        /// <param name="id">Listing ID</param>
        /// <param name="coordinates">New coordinates</param>
        Task UpdateListingCoordinatesAsync(Guid id, Coordinates coordinates);

        /// <summary>
        /// Gets featured listings
        /// </summary>
        /// <param name="limit">Max number of listings</param>
        /// <param name="takeRandomIfNotEnough">If true, random portion of listings will be taken in order to reach limit if possible</param>
        /// <returns>Featured listings</returns>
        Task<List<Listing>> GetFeaturedListingsAsync(int limit = 10, bool takeRandomIfNotEnough = false);

        /// <summary>
        /// Searches for the listings using specified request
        /// </summary>
        /// <param name="search">Search request</param>
        /// <returns>Paginated results</returns>
        Task<ListingSearchResult> SearchAsync(ListingSearchRequest search);

        /// <summary>
        /// GEts suggestions for typeahead type search
        /// </summary>
        /// <param name="query">Search query</param>
        /// <param name="limit">Limit of results</param>
        /// <returns>Search suggestions</returns>
        Task<ListingSearchSuggestion[]> GetListingSearchSuggestionsAsync(string query, int limit = 5);

        /// <summary>
        /// Marks listing as feature
        /// </summary>
        /// <param name="listingId">Id of the listing</param>
        /// <param name="isFeatured">Is listing featured or not</param>
        Task MarkListingAsFeaturedAsync(Guid listingId, bool isFeatured);

        /// <summary>
        /// Marks listing as disabled
        /// </summary>
        /// <param name="listingId">Id of the listing</param>
        /// <param name="isDisabled">Is listing disabled</param>
        Task MarkListingAsDisabledAsync(Guid listingId, bool isDisabled);

        /// <summary>
        /// Increment number listing views
        /// </summary>
        /// <param name="listingId">Id of the listing</param>
        Task IncrementListingViews(Guid listingId);

        /// Gets similar listings (same transaction type, same property type)
        /// </summary>
        /// <param name="listingId">Id of the listing to compare to</param>
        /// <param name="maxPriceDelta">Max price difference (from 0 to 1)</param>
        /// <param name="maxDistinaceInKm">Max distance in km. If is null - ignored</param>
        /// <param name="maxNumberOfListings">Maximum number of listings</param>
        /// <returns>Similar listings</returns>
        Task<List<Listing>> GetSimilarListingsAsync(Guid listingId, double maxPriceDelta = 0.1, double? maxDistinaceInKm = null, int maxNumberOfListings = 10);
    }
}
