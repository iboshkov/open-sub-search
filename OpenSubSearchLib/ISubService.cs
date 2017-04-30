using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenSubSearchLib
{
    public interface ISubService
    {
        IList<Subtitle> searchSubtitlesFromFile(string languages, string filePath);
        IList<Subtitle> searchSubtitlesFromQuery(string languages, string query, int? season = null, int? episode = null);

        IList<Language> getAvailableLanguages();
        Task<IList<Subtitle>> searchSubtitlesFromFileAsync(string languages, string filePath);
        Task<IList<Subtitle>> searchSubtitlesFromQueryAsync(string languages, string query, int? season = null, int? episode = null);

        Task<IList<Language>> getAvailableLanguagesAsync();

        string serviceId();
    }
}