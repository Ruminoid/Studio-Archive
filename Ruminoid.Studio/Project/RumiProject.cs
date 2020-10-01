using System.Collections.ObjectModel;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace Ruminoid.Studio.Project
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RumiProject : MvxViewModel
    {
        #region Project Settings

        [JsonProperty("title")]
        private string _title = "";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        [JsonProperty("width")]
        private int _width;

        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        [JsonProperty("height")]
        private int _height;

        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
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

        #endregion
    }
}
