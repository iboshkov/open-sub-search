using System.Collections.Generic;

namespace OpenSubSearchLib
{
    public interface ISubService
    {
        IList<Subtitle> searchSubtitlesFromFile(string languages, string filePath);
        IList<Subtitle> searchSubtitlesFromQuery(string languages, string query, int? season = null, int? episode = null);

        IList<Language> getAvailableLanguages();

        string serviceId();
    }
}