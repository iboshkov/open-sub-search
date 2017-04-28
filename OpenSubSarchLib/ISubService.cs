using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSDBnet;

namespace OpenSubSarchLib
{
    public class Subtitle
    {
        public string id { get; set; }

        public string hash { get; set; }

        public string fileName { get; set; }

        public string moveId { get; set; }

        public string imdbId { get; set; }

        public string title { get; set; }

        public string originalTitle { get; set; }

        public int year { get; set; }

        public string languageId { get; set; }

        public string languageName { get; set; }

        public string rating { get; set; }

        public string bad { get; set; }

        public Uri downloadLink { get; set; }

        public Uri pageLink { get; set; }
    }

    public class Language
    {
        public String id_iso639;
        public String service_id;
        public String name;

        public override string ToString()
        {
            return name;
        }
    }

    public interface ISubService
    {
        IList<Subtitle> searchSubtitlesFromFile(string languages, string filePath);
        IList<Subtitle> searchSubtitlesFromQuery(string languages, string query, int? season = null, int? episode = null);

        IList<Language> getAvailableLanguages();

        string serviceId();
    }

    public class SubServiceFactory
    {
        private Dictionary<String, ISubService> svcMap;

        public SubServiceFactory()
        {
            svcMap = new Dictionary<string, ISubService>();
            OSDBService svc = new OSDBService();
            svcMap[svc.serviceId()] = svc;
        }

        public ISubService getService(string id)
        {
            return svcMap[id];
        }

        public List<String> getServiceIds()
        {
            return svcMap.Keys.ToList();
        }

        public ISubService getFirstService()
        {
            return svcMap.Values.ToList()[0];
        }
    }
}
