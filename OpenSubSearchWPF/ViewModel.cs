using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OpenSubSearchLib;
using OpenSubSearchWPF.Annotations;

namespace OpenSubSearchWPF
{
    public enum SearchType
    {
        ST_NONE,
        ST_QUERY,
        ST_HASH
    }

    public class ViewModel : INotifyPropertyChanged
    {
        private bool _isWorking;
        private IList<Language> _languages;
        private Language _selectedLanguage;
        private Subtitle _selectedSubtitle;
        private IList<Subtitle> _subtitles;
        private Metadata _metadata;
        private string _activeFilePath;
        private string _downloadMessage;
        private string _query;
        private Visibility _loadingVisibility;
        private bool _canSearchByHash;

        public SearchType lastSearchType { get; set; } = SearchType.ST_NONE;
        public Subtitle selectedSubtitle
        {
            get => _selectedSubtitle;
            set
            {
                _selectedSubtitle = value;
                OnPropertyChanged(nameof(selectedSubtitle));
            }
        }


        public bool canSearchByHash
        {
            get => _canSearchByHash;
            set
            {
                _canSearchByHash = activeFilePath != null && !isWorking;
                OnPropertyChanged(nameof(canSearchByHash));
            }
        }

        public string activeFilePath
        {
            get => _activeFilePath;
            set
            {
                _activeFilePath = value;
                canSearchByHash = false; // just refresh it;
                OnPropertyChanged(nameof(activeFilePath));
            }
        }
        public string downloadMessage
        {
            get => _downloadMessage;
            set
            {
                _downloadMessage = value;
                OnPropertyChanged(nameof(downloadMessage));
            }
        }

        public string query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged(nameof(query));
            }
        }

        public Metadata metadata
        {
            get => _metadata;
            set
            {
                _metadata = value;
                OnPropertyChanged(nameof(metadata));
            }
        }

        public bool isWorking
        {
            get => _isWorking;
            set
            {
                _isWorking = value;
                loadingVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                canSearchByHash = false; // just refresh it;
                OnPropertyChanged(nameof(isWorking));
            }
        }


        public Visibility loadingVisibility
        {
            get { return _loadingVisibility; }
            set
            {
                _loadingVisibility = value;
                OnPropertyChanged(nameof(loadingVisibility));
            }
        }

        public Language selectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;

                OnPropertyChanged(nameof(selectedLanguage));
            }
        }

        public IList<Language> languages
        {
            get => _languages;
            set
            {
                _languages = value;

                OnPropertyChanged(nameof(languages));
            }
        }

        public IList<Subtitle> subtitles
        {
            get => _subtitles;
            set
            {
                _subtitles = value;

                OnPropertyChanged(nameof(subtitles));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}