using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OpenSubSearchLib;

namespace OpenSubSearchWPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly SubServiceFactory _subServiceFactory;
        private readonly bool debug = false;
        private readonly DispatcherTimer searchTimer;
        private readonly ISubService service;

        private readonly ViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            _subServiceFactory = new SubServiceFactory("WPF");
            service = _subServiceFactory.getFirstService();
            searchTimer = new DispatcherTimer();
            searchTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            searchTimer.Tick += searchTimer_Tick;
            vm = new ViewModel();
            DataContext = vm;
            /*
                         <Controls:MetroProgressBar Visibility="{Binding loadingVisibility}" Height="10" x:Name="progressBar"
                                       Grid.Row="2" IsIndeterminate="{Binding isWorking}" />

             */
            vm.PropertyChanged += OnPropertyChanged;
            vm.subtitles = new List<Subtitle>();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "isWorking")
                if (vm.isWorking)
                {
                    transitioner.Content = new MetroProgressBar
                    {
                        IsIndeterminate = true
                    };
                }
                else
                {
                    var resultType = vm.lastSearchType == SearchType.ST_QUERY ? "query" : "hash";
                    var text = $"Found {vm.subtitles.Count} results from {resultType}.";
                    if (vm.lastSearchType == SearchType.ST_NONE)
                        text = $"Drag and drop a file to search for subtitles.";

                    transitioner.Content = new TextBlock
                    {
                        Text = text,
                        Padding = new Thickness(5),
                        FontFamily = new FontFamily("Roboto Light")
                    };
                }
        }

        private async void searchTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Doing query");

            searchTimer.Stop();
            var query = vm.query;
            if (query.Trim().Length == 0)
                return;

            vm.isWorking = true;
            if (debug)
            {
                await Task.Run(() => Thread.Sleep(3000));
                vm.subtitles = new List<Subtitle>
                {
                    new Subtitle
                    {
                        fileName = "Doctor.Who.2005.S10E02.720p.HDTV.x264-FoV[eztv]",
                        rating = "0",
                        languageName = "English"
                    },
                    new Subtitle
                    {
                        fileName = "Doctor.Who.2005.S10E02.1080p.HEVC.x265-MeGusta",
                        rating = "10.0",
                        languageName = "English"
                    }
                };
            }
            else
            {
                vm.lastSearchType = SearchType.ST_QUERY;
                try
                {
                    vm.subtitles = await service.searchSubtitlesFromQueryAsync(vm.selectedLanguage.service_id, query);
                }
                catch
                {
                    this.ShowMessageAsync("Error", "An error happened while fetching subtitles, please try again.");
                }
            }
            vm.isWorking = false;
            Console.WriteLine($"Got {vm.subtitles.Count} subs for query '{query}'");
        }

        private void queryTB_TextInput(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine((e.Source as TextBox).Text);
            searchTimer.Stop();
            searchTimer.Start();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (debug)
            {
                vm.languages = new List<Language>
                {
                    new Language
                    {
                        id_iso639 = "en",
                        name = "English",
                        service_id = "eng"
                    }
                };
            }
            else
            {
                vm.isWorking = true;
                vm.languages = await service.getAvailableLanguagesAsync();
            }

            languagesCB.SelectedItem = vm.languages.First(language => language.id_iso639 == "en");
            languagesCB.IsEnabled = true;
            vm.isWorking = false;

            Console.WriteLine("Loaded languages");
            queryTB.Focus();
        }

        private void MetroWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (vm.isWorking)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = DragDropEffects.Copy;
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = DragDropEffects.Copy;
        }

        private void MetroWindow_Drop(object sender, DragEventArgs e)
        {
            if (vm.isWorking)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = DragDropEffects.Copy;
                return;
            }

            var filePaths = (string[]) e.Data.GetData(DataFormats.FileDrop);
            foreach (var fileLoc in filePaths)
            {
                Console.WriteLine(fileLoc);
                processFile(fileLoc);
            }
        }

        private void processFile(string filepath)
        {
            var filename = Path.GetFileNameWithoutExtension(filepath);
            var parser = new FilenameParser(filename);
            vm.metadata = parser.parse();
            vm.activeFilePath = filepath;
            var seasonPart = vm.metadata.season != null ? $"S{vm.metadata.season}" : "";
            var episodePart = vm.metadata.episode != null ? $"E{vm.metadata.episode}" : "";
            var groupPart = !string.IsNullOrEmpty(vm.metadata.group) ? vm.metadata.group : "";
            vm.query = $"{vm.metadata.title} {seasonPart} {episodePart} {groupPart}".Trim();
        }

        private void MetroWindow__ClearDragEffects(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
        }

        private async void SearchHash_Click(object sender, RoutedEventArgs e)
        {
            vm.isWorking = true;
            vm.lastSearchType = SearchType.ST_HASH;
            try
            {
                vm.subtitles = await service.searchSubtitlesFromFileAsync(vm.selectedLanguage.service_id, vm.activeFilePath);
            }
            catch
            {
                this.ShowMessageAsync("Error", "An error happened while fetching subtitles, please try again.");
            }
            vm.isWorking = false;
        }

        private void subtitleLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            subtitleInfoFlyout.IsOpen = true; 
        }

        private void Download_Clicked(object sender, RoutedEventArgs e)
        {
            Process.Start(vm.selectedSubtitle.downloadLink.ToString());
        }
    }
}