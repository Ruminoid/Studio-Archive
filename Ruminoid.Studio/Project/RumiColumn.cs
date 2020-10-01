using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace Ruminoid.Studio.Project
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RumiColumn : MvxViewModel
    {
        [JsonProperty("id")]
        private string _id = "";

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        [JsonProperty("title")]
        private string _title = "Dialogue";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        [JsonProperty("transform")]
        private string _transform = "";

        public string Transform
        {
            get => _transform;
            set => SetProperty(ref _transform, value);
        }

        [JsonProperty("target")]
        private string _target = "";

        public string Target
        {
            get => _target;
            set => SetProperty(ref _target, value);
        }
    }
}
