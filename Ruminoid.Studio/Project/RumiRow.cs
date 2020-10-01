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
    public class RumiRow : MvxViewModel
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
    }
}
