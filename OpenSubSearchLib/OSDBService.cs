using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSDBnet;

namespace OpenSubSearchLib
{
    public class OSDBService : ISubService
    {
        private readonly IAnonymousClient client;

        public OSDBService(string clientVersionStr = "")
        {
            client = Osdb.Login("en", "opensubsearch v0.1 " + clientVersionStr);
        }

        public string serviceId()
        {
            return "OSDB_SVC";
        }

        public string serviceName()
        {
            return "OpenSubtitles.org";
        }

        public string serviceUrl()
        {
            return "https://OpenSubtitles.org";
        }

        public IList<Subtitle> searchSubtitlesFromFile(string languages, string filePath)
        {
            return remapList(client.SearchSubtitlesFromFile(languages, filePath));
        }

        public IList<Language> getAvailableLanguages()
        {
            return client.GetSubLanguages()
                .Select(lang => new Language
                {
                    name = lang.LanguageName,
                    id_iso639 = lang.ISO639,
                    service_id = lang.SubLanguageID
                })
                .ToList();
        }

        public async Task<IList<Subtitle>> searchSubtitlesFromFileAsync(string languages, string filePath)
        {
            return await Task.Run(() => searchSubtitlesFromFile(languages, filePath));
        }

        public async Task<IList<Subtitle>> searchSubtitlesFromQueryAsync(string languages, string query,
            int? season = null, int? episode = null)
        {
            return await Task.Run(() => searchSubtitlesFromQuery(languages, query, season, episode));
        }

        public async Task<IList<Language>> getAvailableLanguagesAsync()
        {
            return await Task.Run(() => getAvailableLanguages());
        }

        public IList<Subtitle> searchSubtitlesFromQuery(string languages, string query, int? season = null,
            int? episode = null)
        {
            return remapList(client.SearchSubtitlesFromQuery(languages, query, season, episode));
        }

        public string downloadSubitleToPath(Subtitle subtitle, string path, string newName = null)
        {
            return client.DownloadSubtitleToPath(path, subtitle.serviceSubtitle as OSDBnet.Subtitle,
                newName);
        }

        public Task<string> downloadSubitleToPathAsync(Subtitle subtitle, string path, string newName = null)
        {
            return Task.Run(() => client.DownloadSubtitleToPath(path, subtitle.serviceSubtitle as OSDBnet.Subtitle,
                newName));
        }

        private IList<Subtitle> remapList(IList<OSDBnet.Subtitle> input)
        {
            return input.Select(sub => new Subtitle
                {
                    id = sub.SubtitleId,
                    fileName = sub.SubtitleFileName,
                    title = sub.MovieName,
                    year = sub.MovieYear,
                    hash = sub.SubtitleHash,
                    originalTitle = sub.OriginalMovieName,
                    languageName = sub.LanguageName,
                    languageId = sub.LanguageId,
                    rating = sub.Rating,
                    bad = sub.Bad,
                    imdbId = sub.ImdbId,
                    downloadLink = sub.SubTitleDownloadLink,
                    pageLink = sub.SubtitlePageLink,
                    sourceId = serviceId(),
                    sourceName = serviceName(),
                    serviceSubtitle = sub
                })
                .ToList();
        }
    }
}