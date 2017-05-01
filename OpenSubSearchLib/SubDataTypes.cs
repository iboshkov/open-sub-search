using System;
using System.Text;
using System.Threading.Tasks;
using OSDBnet;

namespace OpenSubSearchLib
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
        public string sourceId { get; set; }
        public string sourceName { get; set; }
        public string bad { get; set; }
        public Uri downloadLink { get; set; }
        public Uri pageLink { get; set; }
        public object serviceSubtitle { get; set; }
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
}
