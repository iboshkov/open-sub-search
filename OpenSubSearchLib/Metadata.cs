using System;
using System.Collections.Generic;

namespace OpenSubSearchLib
{
    public class Metadata
    {
        public String input;

        public String title;
        public int? season;
        public int? episode;
        public int? year;
        public String quality;
        public String resolution;
        public String group;
        public String codec;
        public String audio;
        public String map;
        public Dictionary<String, String> _sourceDict;

        public enum MetadataType
        {
            MT_MOVIE,
            MT_SHOW
        }

        public bool tryParseInt(Dictionary<String, String> dict, String key, out Int32 value)
        {
            if (dict.ContainsKey(key))
            {
                bool res = Int32.TryParse(dict[key], out value);
                if (!res)
                {
                    Console.WriteLine($"Couldn't parse '{key}' as int.");
                }
                return res;
            }
            Console.WriteLine($"Couldn't find '{key}' in dict.");

            value = -1;
            return false;
        }

        public bool tryParseBool(Dictionary<String, String> dict, String key, out bool value)
        {
            if (dict.ContainsKey(key))
            {
                bool res = bool.TryParse(dict[key], out value);
                if (!res)
                {
                    Console.WriteLine($"Couldn't parse '{key}' as bool.");
                }
                return res;
            }
            value = false;
            return false;
        }

        public bool setIfExists(Dictionary<String, String> dict, String key, out String value)
        {
            if (dict.ContainsKey(key))
            {
                value = dict[key];
                return true;
            }
            Console.WriteLine($"Couldn't find '{key}' in dict.");

            value = "";
            return false;
        }

        public void _fromDictionary(Dictionary<String, String> dict)
        {
            _sourceDict = dict;
            int season = -1;
            bool valid = tryParseInt(dict, "season", out season);
            if (valid) this.season = season;
            int episode = -1;
            valid = tryParseInt(dict, "episode", out episode);
            if (valid) this.episode = episode;
            int year = -1;
            valid = tryParseInt(dict, "year", out year);
            if (valid) this.year = year;
            setIfExists(dict, "title", out title);
            setIfExists(dict, "quality", out quality);
            setIfExists(dict, "group", out group);
            setIfExists(dict, "codec", out codec);
            setIfExists(dict, "audio", out audio);
        }

        public override string ToString()
        {
            return $"Title:\t\t\t {title}\n"
                   + $"Season:\t\t\t {season}\n"
                   + $"Episode:\t\t {episode}\n"
                   + $"Group:\t\t\t {group}\n"
                   + $"Codec:\t\t\t {codec}\n"
                   + $"Quality:\t\t {quality}\n"
                   + $"Input:\t\t\t {input}\n"
                   ;
        }
    }
}