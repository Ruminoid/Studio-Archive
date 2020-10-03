using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace Ruminoid.Studio.Project
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RumiSettings : MvxNotifyPropertyChanged
    {
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
    }
}
