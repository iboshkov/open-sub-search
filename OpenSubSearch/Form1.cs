using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OpenSubSearchLib;

namespace OpenSubSearch
{
    public partial class Form1 : Form
    {
        private Metadata _meta;

        private List<Subtitle> _subList;
        private string activeFilePath = null;
        private readonly ISubService service;
        private readonly SubServiceFactory subServiceFactory;

        class SearchData
        {
            public Metadata meta;
            public Language language;
            public string filePath;
            public bool includeYear;
            public bool includeGroup;
            public bool includeQuality;
        }

        public Form1()
        {
            InitializeComponent();
            subServiceFactory = new SubServiceFactory();
            service = subServiceFactory.getFirstService();
            languageCBB.Items.Add(new Language()
            {
                service_id = "",
                name = "Any",
                id_iso639 = ""
            });
            languageCBB.Items.AddRange(languages.ToArray());
            Language item = languages.First(language => language.id_iso639 == "en");
            languageCBB.SelectedIndex = 0;
            meta = new Metadata();
        }

        private Metadata meta
        {
            get => _meta;
            set
            {
                _meta = value;
                meta_changed();
            }
        }

        private IList<Language> languages => service.getAvailableLanguages();

        private bool includeReleaseGroup => includeReleaseGroupCB.Checked;
        private bool includeYear => includeYearCB.Checked;
        private bool includeQuality => includeQualityCB.Checked;

        protected List<Subtitle> subList
        {
            get => _subList;
            set
            {
                _subList = value;
                sublist_changed();
            }
        }

        private void sublist_changed()
        {
            listView1.Items.Clear();
            var items = subList.Select(sub => new ListViewItem(sub.languageName)
                {
                    SubItems = {sub.year.ToString(), sub.fileName, sub.rating.ToString()},
                    Tag = sub
                })
                .ToArray();

            listView1.Items.AddRange(items);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            searchCoumtLabel.Text = $"Found {items.Length} results.";
        }

        public void meta_changed()
        {
            meta_title.Text = meta.title;
            meta_season.Text = meta.season != null ? meta.season.ToString() : "";
            meta_episode.Text = meta.episode != null ? meta.episode.ToString() : "";
            meta_year.Text = meta.year != null ? meta.year.ToString() : "";
            meta_group.Text = meta.group;
            meta_quality.Text = meta.quality;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine(openFileDialog1.FileName);
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                processFile(openFileDialog1.FileName);
            updateUIState();
        }

        private void processFile(string filepath)
        {
            var filename = Path.GetFileNameWithoutExtension(filepath);
            var parser = new FilenameParser(filename);
            meta = parser.parse();
            activeFilePath = filepath;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (searchWorker.IsBusy)
                return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var filePaths = (string[]) e.Data.GetData(DataFormats.FileDrop);
                foreach (var fileLoc in filePaths)
                {
                    Console.WriteLine(fileLoc);
                    processFile(fileLoc);
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (searchWorker.IsBusy)
                return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void searchName_Click(object sender, EventArgs e)
        {
            hashProgress.Style = ProgressBarStyle.Marquee;

            searchWorker.RunWorkerAsync(new SearchData()
            {
                meta = meta,
                language = languageCBB.SelectedItem as Language,
                includeYear = this.includeYear,
                includeGroup = this.includeReleaseGroup,
                includeQuality = this.includeQuality
            });
            updateUIState();
        }

        private void searchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = e.Argument as SearchData;

            if (string.IsNullOrEmpty(data.filePath))
            {
                var meta = data.meta;
                var query = meta.title;
                query += data.includeYear && meta.year != null ? $" {meta.year}" : "";
                query += data.includeQuality && !string.IsNullOrEmpty(meta.quality) ? $" {meta.quality}" : "";
                query += data.includeGroup && !string.IsNullOrEmpty(meta.group) ? $" {meta.group}" : "";
                e.Result = service.searchSubtitlesFromQuery(data.language.service_id, query, meta.season, meta.episode);
            } else if (!string.IsNullOrEmpty(data.filePath))
            {
                e.Result = service.searchSubtitlesFromFile(data.language.service_id, data.filePath);
            }
        }

        private void searchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            hashProgress.Style = ProgressBarStyle.Blocks;
            var result = e.Result as List<Subtitle>;
            subList = result;
            updateUIState();
        }

        private void searchHash_Click(object sender, EventArgs e)
        {
            hashProgress.Style = ProgressBarStyle.Marquee;
            searchWorker.RunWorkerAsync(new SearchData()
            {
                filePath = activeFilePath,
                language = languageCBB.SelectedItem as Language
            });
            updateUIState();
        }

        private void download_Click(object sender, EventArgs e)
        {
            var sub = listView1.SelectedItems[0].Tag as Subtitle;
            Process.Start(sub.downloadLink.ToString());
        }

        private void meta_season_TextChanged(object sender, EventArgs e)
        {
            var outSeason = -1;
            var valid = int.TryParse(meta_season.Text, out outSeason);
            int? res = outSeason;
            meta.season = valid ? res : null;
        }

        private void meta_episode_TextChanged(object sender, EventArgs e)
        {
            var outEpisode = -1;
            var valid = int.TryParse(meta_episode.Text, out outEpisode);
            int? res = outEpisode;

            meta.episode = valid ? res : null;
        }

        private void meta_year_TextChanged(object sender, EventArgs e)
        {
            var outYear = -1;
            var valid = int.TryParse(meta_year.Text, out outYear);
            int? res = outYear;

            meta.year = valid ? res : null;
        }

        private void meta_group_TextChanged(object sender, EventArgs e)
        {
            meta.group = meta_group.Text;
        }

        private void meta_quality_TextChanged(object sender, EventArgs e)
        {
            meta.quality = meta_quality.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void subPageButton_Click(object sender, EventArgs e)
        {
            Subtitle sub = listView1.SelectedItems[0].Tag as Subtitle;
            Process.Start(sub.pageLink.ToString());
        }

        protected void updateUIState()
        {
            bool canSearch = meta_title.Text.Trim().Length > 0;
            bool subSelected = listView1.SelectedItems.Count > 0;
            searchNameButton.Enabled = canSearch;
            searchHashButton.Enabled = activeFilePath != null;
            downloadButton.Enabled = subSelected;
            subPageButton.Enabled = subSelected;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateUIState();
        }

        private void meta_title_TextChanged(object sender, EventArgs e)
        {
            meta.title = meta_title.Text;
            updateUIState();
        }
    }
}