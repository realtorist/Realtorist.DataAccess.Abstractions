using System.Threading.Tasks;

namespace Realtorist.DataAccess.Abstractions
{
    /// <summary>
    /// Describes access to the website settings
    /// </summary>
    public interface ISettingsDataAccess
    {
        /// <summary>
        /// Gets settings
        /// </summary>
        /// <param name="type">Setting type</param>
        /// <returns>Setting</returns>
        Task<T> GetSettingAsync<T>(string type) where T : new();

        /// <summary>
        /// Gets settings
        /// </summary>
        /// <param name="type">Setting type</param>
        /// <returns>Setting</returns>
        Task<dynamic> GetSettingAsync(string type);

        /// <summary>
        /// Replaces settings by new one
        /// </summary>
        /// <param name="type">Setting type</param>
        /// <param name="newSettings">New settings</param>
        Task UpdateSettingsAsync(string type, object newSettings);
    }
}
