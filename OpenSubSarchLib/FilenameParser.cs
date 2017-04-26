using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace OpenSubSearchLib
{
    /*
     * Adapted from: https://github.com/divijbindlish/parse-torrent-name
     */
    public partial class FilenameParser
    {
        public static Dictionary<String, String> patterns = new Dictionary<String, String>()
        {
            {"season", "(s?([0-9]{1,2}))[ex]"},
            {"episode", "([ex]([0-9]{2})(?:[^0-9]|$))"},
            {"year", "([\\[\\(]?((?:19[0-9]|20[0-9])[0-9])[\\]\\)]?)"},
            {"resolution", "([0-9]{3,4}p)"},
            {
                "quality",
                "((?:PPV\\.)?[HP]DTV|(?:HD)?CAM|B[DR]Rip|(?:HD-?)?TS|(?:PPV )?WEB-?DL(?: DVDRip)?|HDRip|DVDRip|DVDRIP|CamRip|W[EB]BRip|BluRay|DvDScr|hdtv|telesync)"
            },
            {"codec", "(xvid|[hx]\\.?26[45])"},
            {"audio", "(MP3|DD5\\.?1|Dual[\\- ]Audio|LiNE|DTS|AAC[.-]LC|AAC(?:\\.?2\\.0)?|AC3(?:\\.5\\.1)?)"},
            {"group", "(- ?([^-]+(?:-={[^-]+-?$)?))$"},
            {"region", "R[0-9]"},
            {"extended", "(EXTENDED(:?.CUT)?)"},
            {"hardcoded", "HC"},
            {"proper", "PROPER"},
            {"repack", "REPACK"},
            {"container", "(MKV|AVI|MP4)"},
            {"widescreen", "WS"},
            {"website", "^(\\[ ?([^\\]]+?) ?\\])"},
            {"language", "(rus\\.eng|ita\\.eng)"},
            {"sbs", "(?:Half-)?SBS"},
            {"unrated", "UNRATED"},
            {"size", "(\\d+(?:\\.\\d+)?(?:GB|MB))"},
            {"3d", "3D"}
        };

        private Metadata meta;
        private Int32 start = -1;
        private Int32 end = -1;
        private Dictionary<String, String> parts;
        public String group_raw;
        public String title_raw;
        public String excess_raw;

        public FilenameParser(String filename)
        {
            meta = new Metadata {input = filename};
            parts = new Dictionary<String, String>();
            group_raw = title_raw = excess_raw = "";
            start = 0;
            end = -1;
            excess_raw = meta.input;
        }

        protected void part(String name, GroupCollection groups, String raw, String clean, int raw_idx, int clean_idx)
        {
            parts[name] = clean;

            if (groups == null)
            {
                return;
            }

            Group match = groups[raw_idx];
            if (match.Index == 0)
            {
                start = match.Length;
            }
            else if (end < 0 || match.Index < end)
            {
                end = match.Index;
            }

            if (name != "excess")
            {
                if (name == "group")
                    group_raw = raw;
                if (excess_raw.Length > 0)
                    excess_raw = raw.Replace(excess_raw, raw);
            }
        }

        protected String escape_regex(String str)
        {
            return Regex.Replace(str, "[\\-\\[\\]{}()*+?.,\\\\\\^$|#\\s]", "$&");
        }

        public Metadata parse()
        {
            string raw;
            string clean;
            foreach (KeyValuePair<String, String> kv in patterns)
            {
                var key = kv.Key;
                var pattern = kv.Value;

                var clean_name = Regex.Replace(meta.input, "_", " ");

                MatchCollection matches = Regex.Matches(clean_name, pattern, RegexOptions.IgnoreCase);

                if (matches.Count == 0)
                    continue;

                Match match = matches[0];
                GroupCollection groups = match.Groups;

                var clean_idx = groups.Count - 1;
                var raw_idx = 0;
                raw = groups[raw_idx].ToString();
                clean = groups[clean_idx].ToString();


                if (key == "group")
                {
                    MatchCollection codec_matches = Regex.Matches(clean, patterns["codec"], RegexOptions.IgnoreCase);
                    MatchCollection quality_matches =
                        Regex.Matches(clean, patterns["quality"], RegexOptions.IgnoreCase);
                    if (codec_matches.Count > 0 || quality_matches.Count > 0) // Not group - codec or qualtiy, move on
                        continue;
                    if (Regex.Match(clean, "[^ ]+ [^ ]+ .+").Success)
                    {
                        key = "episodeName";
                    }
                }

                if (key == "episode")
                {
                    String sub_pattern = escape_regex(raw);
                    meta.map = Regex.Replace(clean_name, sub_pattern, "{episode}");
                }

                part(key, match.Groups, raw, clean, raw_idx, clean_idx);
            }

            raw = meta.input;

            if (end >= 0)
            {
                raw = raw.Substring(start, end - start).Split('(')[0];
            }

            clean = Regex.Replace(raw, "^ -", "");

            if (clean.IndexOf(" ") == -1 && clean.IndexOf(".") != -1)
            {
                clean = Regex.Replace(clean, "\\.", " ");
            }
            clean = Regex.Replace(clean, "_", " ");
            clean = Regex.Replace(clean, "([\\[\\(_]|- )$", "").Trim();

            part("title", null, raw, clean, -1, -1);

            //            clean = Regex.Replace(excess_raw, "(^[-\\. ()]+)|([-\\. ]+$)", "");
            //            clean = Regex.Replace(clean, "[\\(\\)\\/]", " ");
            // TODO: The rest.
            meta._fromDictionary(parts);
            return meta;
        }
    }
}