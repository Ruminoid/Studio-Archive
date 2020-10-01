using System.Collections.ObjectModel;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace Ruminoid.Studio.Project
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RumiProject : MvxViewModel
    {
        [JsonProperty]
        private RumiSettings _settings;

        public RumiSettings Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        [JsonProperty("styles")]
        private ObservableCollection<RumiStyle> _styles;

        public ObservableCollection<RumiStyle> Styles
        {
            get => _styles;
            set => SetProperty(ref _styles, value);
        }

        [JsonProperty("rows")]
        private ObservableCollection<RumiRow> _rows;

        public ObservableCollection<RumiRow> Rows
        {
            get => _rows;
            set => SetProperty(ref _rows, value);
        }

        [JsonProperty("columns")]
        private ObservableCollection<RumiColumn> _columns;

        public ObservableCollection<RumiColumn> Columns
        {
            get => _columns;
            set => SetProperty(ref _columns, value);
        }
    }
}
