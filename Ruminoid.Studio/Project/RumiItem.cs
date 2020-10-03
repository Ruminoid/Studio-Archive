using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace Ruminoid.Studio.Project
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RumiItem : MvxNotifyPropertyChanged
    {
        [JsonProperty("id")]
        private string _id = "";

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        [JsonProperty("row")]
        private string _row = "";

        public string Row
        {
            get => _row;
            set => SetProperty(ref _row, value);
        }

        [JsonProperty("text")]
        private string _text = "";

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
