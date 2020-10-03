using System.Collections.ObjectModel;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace Ruminoid.Studio.Project
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RumiRow : MvxNotifyPropertyChanged
    {
        [JsonProperty("id")]
        private string _id = "";

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        [JsonProperty("type")]
        private string _type = "Dialogue";

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        [JsonProperty("items")]
        private ObservableCollection<RumiItem> _items;

        public ObservableCollection<RumiItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
    }
}
